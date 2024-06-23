using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MTJM.WebApp.MVC.Controllers.Cliente;

[Authorize]
public class ClienteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
