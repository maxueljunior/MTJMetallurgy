using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Services;

namespace MTJM.WebApp.MVC.Controllers.Servicos;

public class ServicosController : Controller
{
    #region Properties
    private readonly IRequestApiService _requestApiService;
    #endregion

    #region Constructor
    public ServicosController(IRequestApiService requestApiService)
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

    #region GET - Get All
    public async Task<IActionResult> GetAll()
    {
        var response = await _requestApiService.Request("Servico/GetAll", Method.GET);

        var responseContent = await response.Content.ReadAsStringAsync();

        return Json(new CustomResponse().WithSuccess(JsonHelper.JsonToObject<List<ServicoDTO>>(responseContent)));
        
    }
    #endregion

    
}
