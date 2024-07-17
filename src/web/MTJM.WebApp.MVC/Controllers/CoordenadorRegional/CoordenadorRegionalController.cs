using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.Attributes;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Models.Funcionarios;
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

    #region Methods

    #region GET - Index
    [ClaimsAuthorize(PermissionsType.CRV, PermissionValue.Read)]
    public IActionResult Index()
    {
        return View();
    }
    #endregion

    #region GET - GetTableCRV
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
    #endregion

    #region GET - Create
    public IActionResult Create()
    {
        return View();
    }
    #endregion

    #region POST - Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ClaimsAuthorize(PermissionsType.CRV, PermissionValue.Create)]
    public async Task<IActionResult> Create(CoordenadorRegionalViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request("CoordenadorRegional/Create", Method.POST, viewModel);

        if (response.IsSuccessStatusCode) {
            TempData["SuccessMessage"] = "Coordenador Regional create successfully!";
            return RedirectToAction("Index", "CoordenadorRegional");
        }

        ViewBag.ErrorCreate = "Unexpected error!";
        return View(viewModel);
    }

    #endregion

    #region GET - Edit
    public async Task<IActionResult> Edit(int id)
    {
        if (id < 0)
        {
            TempData["ErrorMessage"] = "Id is required!";
            return RedirectToAction("Index", "CoordenadorRegional");
        }

        var response = await _requestApiService.Request($"CoordenadorRegional/GetById/{id}", Method.GET);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return View(JsonHelper.JsonToObject<CoordenadorRegionalViewModel>(responseContent));

        var CustomResponse = JsonHelper.JsonToObject<CustomResponse>(responseContent);

        TempData["ErrorMessage"] = CustomResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return RedirectToAction("Index", "CoordenadorRegional");

    }
    #endregion

    #region POST - Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0)
            return Json(new CustomResponse().WithError("Id is required"));

        try {
            var response = await _requestApiService.Request($"CoordenadorRegional/Delete/{id}", Method.DELETE);

            if (response.IsSuccessStatusCode)
                return Json(new CustomResponse().WithSuccess());

            var customResponse = JsonHelper.JsonToObject<CustomResponse>(await response.Content.ReadAsStringAsync());

            return Json(new CustomResponse().WithErrors(customResponse));

        } catch (Exception)
        {
            return Json(new CustomResponse().WithError("Occurred a unexpected error!"));
        }
    }
    #endregion

    #endregion
}
