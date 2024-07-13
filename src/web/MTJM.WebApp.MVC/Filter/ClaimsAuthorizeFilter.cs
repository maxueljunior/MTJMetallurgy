using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MTJM.WebApp.MVC.Helpers;

namespace MTJM.WebApp.MVC.Filter;

public class ClaimsAuthorizeFilter : IActionFilter
{
    private readonly IClaimsHelpers _claimsHelpers;
    private readonly PermissionsType _permissionType;
    private readonly PermissionValue _permissionValue;

    public ClaimsAuthorizeFilter(IClaimsHelpers claimsHelpers, PermissionsType? permissionType = null, PermissionValue? permissionValue = null)
    {
        _claimsHelpers = claimsHelpers;

        if(permissionType.HasValue)
            _permissionType = permissionType.Value;

        if(permissionValue.HasValue)
            _permissionValue = permissionValue.Value;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // não utilizado...
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var roles = _claimsHelpers.GetRoles();
        var claims = _claimsHelpers.GetClaims();

        if(!roles.Contains("Admin") && !claims.Where(c =>
                c.Type.Equals(_permissionType.ToString()) && c.Value.Contains(_permissionValue.ToString())).Any())
        {
            context.Result = new RedirectToActionResult("Error", "Home", null);
        }
    }
}
