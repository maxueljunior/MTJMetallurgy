using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Auth;
using MTJM.API.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MTJM.API.Controllers.Auth;

[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthServices _authServices;

    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var token = await _authServices.Login(loginDTO);

        if (token is null)
        {
            AdicionaErros("Login or password invalids!");
            return CustomResponse();
        }

        return CustomResponse(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }

    [HttpPost]
    [Route("register")]
    //[ClaimsAuthorize("Admin", "Escrever,Ler")]
    public async Task<IActionResult> Register(RegisterDTO registerDTO)
    {
        if(!await _authServices.Register(registerDTO))
        {
            AdicionaErros("Error create to User");
            return CustomResponse();
        }

        return CustomResponse(new AuthenticationDTO { Status = "Success", Message = "User created successfully!" });
    }
}
