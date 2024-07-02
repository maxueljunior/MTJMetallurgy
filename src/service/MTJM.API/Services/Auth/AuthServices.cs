using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MTJM.API.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MTJM.API.Services.Auth;

public class AuthServices : IAuthServices
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthServices(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<JwtSecurityToken> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.Username);

        if (user is not null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var claim in userClaims)
            {
                authClaims.Add(claim);
            }

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GetToken(authClaims);

            return token;
        }

        return null;
    }

    public async Task<IEnumerable<Claim>> GetClaims(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        return await _userManager.GetClaimsAsync(user);
    }

    public async Task<IdentityUser> GetUser(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<IEnumerable<string>> GetRoles(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        return await _userManager.GetRolesAsync(user);
    }

    public async Task<bool> Register(RegisterDTO registerDTO)
    {
        var userExists = await _userManager.FindByEmailAsync(registerDTO.Email);

        if (userExists is not null)
            return false;

        IdentityUser user = new()
        {
            Email = registerDTO.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerDTO.Username,
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
                return false;

            return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return true;
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
