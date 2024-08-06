using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Models.Funcionarios;
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

    #region GET - Create
    public IActionResult Create() => View();
    #endregion

    #region POST - Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServicosViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request("Servico/Create", Method.POST, viewModel);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Servico create successfully!";
            return RedirectToAction("Index", "Servicos");
        }

        var customResponse = JsonHelper.JsonToObject<CustomResponse>(await response.Content.ReadAsStringAsync());

        TempData["ErrorMessage"] = customResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return View(viewModel);
    }
    #endregion

    #region GET - Edit
    public async Task<IActionResult> Edit(int id)
    {
        if (id < 0)
        {
            TempData["ErrorMessage"] = "Id is required!";
            return RedirectToAction("Index", "Servicos");
        }

        var response = await _requestApiService.Request($"Servico/GetById/{id}", Method.GET);
        var responseContent = await response.Content.ReadAsStringAsync();

        var viewModel = JsonHelper.JsonToObject<ServicosViewModel>(responseContent);

        if (response.IsSuccessStatusCode)
            return View(viewModel);

        var customResponse = JsonHelper.JsonToObject<CustomResponse>(responseContent);

        TempData["ErrorMessage"] = customResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return RedirectToAction("Index", "Servicos");
    }
    #endregion

    #region POST - Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServicosViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request($"Servico/Edit/{id}", Method.PUT, viewModel);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Servico edit successfully!";
            return RedirectToAction("Index", "Servicos");
        }

        var customResponse = JsonHelper.JsonToObject<CustomResponse>(await response.Content.ReadAsStringAsync());

        TempData["ErrorMessage"] = customResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return RedirectToAction("Index", "Servicos");
    }
    #endregion

}
