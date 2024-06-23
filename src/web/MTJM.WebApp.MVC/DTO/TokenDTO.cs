using System.Security.Claims;

namespace MTJM.WebApp.MVC.DTO;

public class TokenDTO
{
    public string Username { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public IEnumerable<Claim> Claims { get; set; }
    public IEnumerable<string> Roles { get; set; }
}
