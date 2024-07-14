using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.Attributes;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Services;

namespace MTJM.WebApp.MVC.Controllers.CoordenadorRegional;

public class CoordenadorRegionalController : Controller
{
    #region Properties
    private readonly IRequestApiService _requestApiService;

    #endregion

    #region Constructor
    public CoordenadorRegionalController(IRequestApiService requestApiService)
    {
        _requestApiService = requestApiService;
    }
    #endregion

    [ClaimsAuthorize(PermissionsType.CRV, PermissionValue.Read)]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetTableCRV()
    {
        var response = await _requestApiService.Request("CoordenadorRegional/GetAll", Method.GET);

        if (response.IsSuccessStatusCode)
        {
            return Json(
                new CustomResponse()
                    .WithSuccess(
                        JsonHelper.JsonToObject<IEnumerable<CoordenadorRegionalDTO>>(await response.Content.ReadAsStringAsync())
                    )
            );
        }

        return Json(new CustomResponse().WithError("Data not found"));
    }
}
