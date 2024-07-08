using System.Security.Claims;

namespace MTJM.WebApp.MVC.DTO;

public class TokenDTO
{
    public string Username { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public IEnumerable<ClaimDTO> Claims { get; set; }
    public IEnumerable<string> Roles { get; set; }
}

public class ClaimDTO
{
    public string Type { get; set; }
    public string Value { get; set; }
}
