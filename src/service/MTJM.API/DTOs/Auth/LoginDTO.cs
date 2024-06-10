using System.ComponentModel.DataAnnotations;

namespace MTJM.API.DTOs.Auth;

public class LoginDTO
{
    [Required(ErrorMessage = "User name is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
