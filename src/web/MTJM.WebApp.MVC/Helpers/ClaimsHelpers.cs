using MTJM.WebApp.MVC.DTO;
using System.Security.Claims;

namespace MTJM.WebApp.MVC.Helpers;

public class ClaimsHelpers : IClaimsHelpers
{
    private readonly IHttpContextAccessor _httpContext;

    public ClaimsHelpers(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public IEnumerable<ClaimDTO> GetClaims()
    {
        List<ClaimDTO> claims = new();
        var permissionsType = Enum.GetValues(typeof(PermissionsType)).Cast<PermissionsType>().ToList();

        permissionsType.ForEach(p =>
        {
            var claim = _httpContext?.HttpContext?.User.FindFirstValue(p.ToString());
            if (!string.IsNullOrEmpty(claim))
            {
                claims.Add(new ClaimDTO
                {
                    Type = p.ToString(),
                    Value = claim
                });
            }
        });

        return claims;
    }

    public IEnumerable<string> GetRoles()
    {
        return _httpContext?.HttpContext?.User.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
    }

    public string GetToken()
    {
        return _httpContext?.HttpContext?.User.FindFirstValue("AccessToken");
    }

    public string GetUsername()
    {
        return _httpContext?.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

    }
}
