using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.Services;

namespace MTJM.WebApp.MVC.Controllers.Orcamentista;

public class OrcamentistaController : Controller
{
    #region Properties
    private readonly IRequestApiService _requestApiService;

    #endregion

    #region Constructor
    public OrcamentistaController(IRequestApiService requestApiService)
    {
        _requestApiService = requestApiService;
    }
    #endregion

    #region GET - Index
    public IActionResult Index()
    {
        return View();
    }
    #endregion
}
