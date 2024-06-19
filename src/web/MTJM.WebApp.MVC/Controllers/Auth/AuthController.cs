using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.Models;
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
            ModelState.AddModelError(string.Empty, "Login or password incorrect...");
            return View(loginViewModel);
        }

        var client = _httpClientFactory.CreateClient();
        var loginData = new StringContent(JsonSerializer.Serialize(loginViewModel), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7009/api/Auth/login", loginData);

        if(response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<TokenResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            HttpContext.Response.Cookies.Append("Auth", token.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = token.Expiration
            });

            return RedirectToAction("Index", "Home");
        }

        return View();
    }
}

public class TokenResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}