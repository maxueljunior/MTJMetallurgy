using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MTJM.API.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MTJM.API.Controllers.Auth;

[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.Username);

        if(user is not null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            return CustomResponse(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        AdicionaErros("Login or password invalids!");

        return CustomResponse();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterDTO registerDTO)
    {
        var userExists = await _userManager.FindByEmailAsync(registerDTO.Email);

        if(userExists is not null)
        {
            AdicionaErros("User already exists!");
            return CustomResponse();
        }

        IdentityUser user = new()
        {
            Email = registerDTO.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerDTO.Username,
        };

        var result = await _userManager.CreateAsync(user, registerDTO.Password);

        if(!result.Succeeded)
        {
            AdicionaErros("Error create to User");
            return CustomResponse();
        }

        return CustomResponse(new AuthenticationDTO { Status = "Success", Message = "User created successfully!" });
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}
