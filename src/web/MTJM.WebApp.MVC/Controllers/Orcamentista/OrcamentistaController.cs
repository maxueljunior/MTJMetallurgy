using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Models.Funcionarios;
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

    #region GET - Create
    public async Task<IActionResult> Create()
    {
        var viewModel = new OrcamentistaViewModel();
        viewModel = await PopulateCrvsWithoutOrcamentista(viewModel);

        return View(viewModel);
    }
    #endregion

    #region POST - Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrcamentistaViewModel viewModel)
    {
        viewModel = await PopulateCrvsWithoutOrcamentista(viewModel);

        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request("Orcamentista/Create", Method.POST, viewModel);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Orcamentista create successfully!";
            return RedirectToAction("Index", "Orcamentista");
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
            return RedirectToAction("Index", "Orcamentista");
        }

        var response = await _requestApiService.Request($"Orcamentista/GetById/{id}", Method.GET);
        var responseContent = await response.Content.ReadAsStringAsync();

        var viewModel = JsonHelper.JsonToObject<OrcamentistaViewModel>(responseContent);
        viewModel = await PopulateCrvsWithoutOrcamentista(viewModel);

        if (response.IsSuccessStatusCode)
            return View(viewModel);

        var customResponse = JsonHelper.JsonToObject<CustomResponse>(responseContent);

        TempData["ErrorMessage"] = customResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return RedirectToAction("Index", "Orcamentista");
    }
    #endregion

    #region GET - Get All
    public async Task<IActionResult> GetAll()
    {
        var response = await _requestApiService.Request("Orcamentista/GetAll", Method.GET);

        if (response.IsSuccessStatusCode)
        {
            return Json(new CustomResponse().WithSuccess(
                JsonHelper.JsonToObject<IEnumerable<OrcamentistaDTO>>(await response.Content.ReadAsStringAsync())
            ));
        }

        return Json(new CustomResponse().WithError("Data not found"));
    }
    #endregion

    #region POST - Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0)
            return Json(new CustomResponse().WithError("Id is required"));

        try
        {
            var response = await _requestApiService.Request($"Orcamentista/Delete/{id}", Method.DELETE);

            if (response.IsSuccessStatusCode)
                return Json(new CustomResponse().WithSuccess());

            var customResponse = JsonHelper.JsonToObject<CustomResponse>(await response.Content.ReadAsStringAsync());

            return Json(new CustomResponse().WithErrors(customResponse));
        }
        catch (Exception)
        {
            return Json(new CustomResponse().WithError("Occurred a unexpected error!"));
        }
    }
    #endregion

    #region Private Methods
    private async Task<OrcamentistaViewModel> PopulateCrvsWithoutOrcamentista(OrcamentistaViewModel viewModel)
    {
        var response = await _requestApiService.Request("CoordenadorRegional/GetAllWithoutOrcamentista", Method.GET);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var Crvs = JsonHelper.JsonToObject<IEnumerable<CoordenadorRegionalDTO>>(responseContent);
            viewModel.crvs = Crvs.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = string.Concat(c.Nome, " ", c.Sobrenome)
            });
        }

        return viewModel;
    }
    #endregion
}
