using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MTJM.WebApp.MVC.Controllers.Auth;

public class AuthController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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

        var client = _httpClientFactory.CreateClient();
        var loginData = new StringContent(JsonSerializer.Serialize(loginViewModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7009/api/Auth/login", loginData);

        if(response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<TokenDTO>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

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
                claims.Add(claim);
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
}

