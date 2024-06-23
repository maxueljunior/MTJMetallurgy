using System.Security.Claims;

namespace MTJM.WebApp.MVC.Helpers;

public interface IClaimsHelpers
{
    string GetToken();
    IEnumerable<string> GetRoles();
    string GetUsername();
}
