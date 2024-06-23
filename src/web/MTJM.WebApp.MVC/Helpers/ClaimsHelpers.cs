using System.Security.Claims;

namespace MTJM.WebApp.MVC.Helpers;

public class ClaimsHelpers : IClaimsHelpers
{
    private readonly IHttpContextAccessor _httpContext;

    public ClaimsHelpers(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
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
