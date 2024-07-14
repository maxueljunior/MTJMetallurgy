using MTJM.WebApp.MVC.DTO;
using System.Security.Claims;

namespace MTJM.WebApp.MVC.Helpers;

public interface IClaimsHelpers
{
    string GetToken();
    IEnumerable<string> GetRoles();
    string GetUsername();
    IEnumerable<ClaimDTO> GetClaims();
    bool UserHaveAccess(PermissionsType permissionsType);
    bool UserHaveAccess(PermissionsType permissionsType, PermissionValue permissionValue);
}
