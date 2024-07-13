using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MTJM.WebApp.MVC.Filter;
using MTJM.WebApp.MVC.Helpers;

namespace MTJM.WebApp.MVC.Attributes;

public class ClaimsAuthorizeAttribute : Attribute, IFilterFactory
{
    private readonly PermissionsType _permissionType;
    private readonly PermissionValue _permissionValue;

    public ClaimsAuthorizeAttribute(PermissionsType permissionType, PermissionValue permissionValue)
    {
        _permissionType = permissionType;
        _permissionValue = permissionValue;
    }

    public bool IsReusable => false;

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        var claimsHelpers = serviceProvider.GetService<IClaimsHelpers>();
        return new ClaimsAuthorizeFilter(claimsHelpers, _permissionType, _permissionValue);
    }
}
