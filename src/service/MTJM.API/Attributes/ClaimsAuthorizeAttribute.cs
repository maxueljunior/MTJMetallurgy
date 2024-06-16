using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MTJM.API.Attributes;

public class ClaimsAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _claimType;
    private readonly string _claimValue;

    public ClaimsAuthorizeAttribute(string claimType, string claimValue)
    {
        _claimType = claimType;
        _claimValue = claimValue;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if(!user.Identity.IsAuthenticated )
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!user.IsInRole("Admin"))
        {
            var claim = user.Claims.FirstOrDefault(c => c.Type == _claimType && c.Value.Contains(_claimValue));

            if (claim is null)
                context.Result = new ForbidResult();
        }

    }
}
