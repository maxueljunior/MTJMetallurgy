using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Handler;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Services;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MTJM.WebApp.MVC.Controllers.Auth;

public class AuthController : Controller
{
    private readonly IRequestApiService _requestService;
    private readonly IClaimsHelpers _claimsHelpers;

    public AuthController(IRequestApiService requestService, IClaimsHelpers claimsHelpers)
    {
        _requestService = requestService;
        _claimsHelpers = claimsHelpers;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(loginViewModel);
        }

        var response = await _requestService.Request("Auth/Login", Method.POST, loginViewModel);

        if(response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            var token = JsonHelper.JsonToObject<TokenDTO>(responseContent);

            HttpContext.Response.Cookies.Append("MTJMCookie", token.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = token.Expiration
            });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginViewModel.Username),
                new Claim("AccessToken", token.Token)
            };

            foreach (var role in token.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach(var claim in token.Claims)
            {
                claims.Add(new Claim(claim.Type, claim.Value));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = token.Expiration
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Login or password incorrect...";
        return View(loginViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        HttpContext.Response.Cookies.Delete("MTJMCookie");

        return RedirectToAction("Login", "Auth");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExistsUsername([FromBody] string username)
    {
        if (string.IsNullOrEmpty(username))
            return Json(new CustomResponse().WithError("Username is required."));

        var response = await _requestService.Request($"auth/existsUsername/{username}", Method.GET);

        var responseContent = await response.Content.ReadAsStringAsync();
        

        if (response.IsSuccessStatusCode)
        {
            return Json(new CustomResponse().WithSuccess());
        }
          
        var customResponse = JsonHelper.JsonToObject<CustomResponse>(responseContent);

        return Json(new CustomResponse().WithErrors(customResponse));
    }

    [HttpGet]
    public IActionResult UserHaveAccess(string permissionType, string permissionValue)
    {
        if (string.IsNullOrEmpty(permissionType))
            return Json(new CustomResponse().WithError("Permission Type is required"));

        if (string.IsNullOrEmpty(permissionValue))
            return Json(new CustomResponse().WithError("Permission Value is required"));

        if (!ValidatePermission<PermissionsType>(permissionType))
            return Json(new CustomResponse().WithError($"Permission Type {permissionType} is invalid!"));

        if(!ValidatePermission<PermissionValue>(permissionValue))
            return Json(new CustomResponse().WithError($"Permission Value {permissionValue} is invalid!"));

        if (_claimsHelpers.GetRoles().Contains("Admin") || _claimsHelpers.GetClaims().Where(c => c.Type == permissionType && c.Value.Contains(permissionValue)).Any())
            return Json(new CustomResponse().WithSuccess());

        return Json(new CustomResponse().WithError("User don't have access in page or function!"));
    }

    private bool ValidatePermission<T>(string permission) where T : Enum
    {
        var ListValuesPermissions = Enum.GetValues(typeof(T)).Cast<T>();

        bool IsValidPermission = true;

        foreach (var valuePermission in ListValuesPermissions)
        {
            if (!valuePermission.ToString().ToLower().Equals(permission.ToLower()))
            {
                IsValidPermission = false;
                continue;
            }

            IsValidPermission = true;
            break;
        }

        return IsValidPermission;
    }
}

