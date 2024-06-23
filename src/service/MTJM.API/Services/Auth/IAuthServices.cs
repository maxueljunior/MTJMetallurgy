using MTJM.API.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MTJM.API.Services.Auth;

public interface IAuthServices
{
    Task<JwtSecurityToken> Login(LoginDTO loginDTO);
    Task<bool> Register(RegisterDTO registerDTO);
    Task<IEnumerable<Claim>> GetClaims(string username);
    Task<IEnumerable<string>> GetRoles(string username);
}
