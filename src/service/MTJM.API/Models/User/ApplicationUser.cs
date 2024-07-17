using Microsoft.AspNetCore.Identity;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Models.User;

public class ApplicationUser : IdentityUser
{
    public Cliente Cliente { get; set; }
    public CoordenadorRegional CoordenadorRegional { get; set; }
}
