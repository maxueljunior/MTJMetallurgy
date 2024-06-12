using MTJM.API.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;

namespace MTJM.API.Services.Auth;

public interface IAuthServices
{
    Task<JwtSecurityToken> Login(LoginDTO loginDTO);
    Task<bool> Register(RegisterDTO registerDTO);
}
