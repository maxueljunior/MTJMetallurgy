using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using System.Diagnostics;

namespace MTJM.WebApp.MVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IClaimsHelpers _claimsHelpers;

    public HomeController(IClaimsHelpers claimsHelpers)
    {
        _claimsHelpers = claimsHelpers;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
