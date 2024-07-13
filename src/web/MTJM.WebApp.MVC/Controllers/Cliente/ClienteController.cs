using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTJM.WebApp.MVC.Attributes;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Models;
using MTJM.WebApp.MVC.Services;
using System.Text.Json;

namespace MTJM.WebApp.MVC.Controllers.Cliente;

[Authorize]
public class ClienteController : Controller
{
    #region Properties
    private readonly IRequestApiService _requestApiService;
    #endregion

    #region Constructors
    public ClienteController(IRequestApiService requestApiService)
    {
        _requestApiService = requestApiService;
    }
    #endregion

    #region Index
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Read)]
    public IActionResult Index()
    {
        return View();
    }
    #endregion

    #region GET - GetTableClientes
    [HttpGet]
    public async Task<IActionResult> GetTableClientes()
    {
        var response = await _requestApiService.Request("Cliente/GetAll", Models.Method.GET);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var clientes = JsonSerializer.Deserialize<IEnumerable<ClienteDTO>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Json(clientes);
        }

        return Json(null);
    }
    #endregion

    #region GET - Create
    [HttpGet]
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Create)]
    public async Task<IActionResult> Create()
    {
        var viewModel = new ClienteViewModel();
        viewModel = await PopulateCrvs(viewModel);

        return View(viewModel);
    }
    #endregion

    #region POST - Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Create)]
    public async Task<IActionResult> Create(ClienteViewModel viewModel)
    {
        viewModel = await PopulateCrvs(viewModel);

        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request("Cliente/Create", Method.POST, viewModel);

        if (response.IsSuccessStatusCode) { 
            TempData["SuccessMessage"] = "Cliente create successfully!";
            return RedirectToAction("Index", "Cliente");
        }

        ViewBag.ErrorCreate = "Unexpected error!";
        return View(viewModel);
    }
    #endregion

    #region GET - Edit
    [HttpGet]
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Update)]
    public async Task<IActionResult> Edit(int id) { 

        if(id < 0)
        {
            TempData["ErrorMessage"] = "Id Cliente is required!";
            return RedirectToAction("Index", "Cliente");
        }

        var response = await _requestApiService.Request($"Cliente/GetById/{id}", Method.GET);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var Cliente = JsonHelper.JsonToObject<ClienteViewModel>(responseContent);
            return View(await PopulateCrvs(Cliente));
        }

        var CustomResponse = JsonHelper.JsonToObject<CustomResponse>(responseContent);

        TempData["ErrorMessage"] = CustomResponse.Errors.Values.First().First() ?? "Occurred inexpected error";

        return RedirectToAction("Index", "Cliente");
    }
    #endregion

    #region POST - Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Update)]
    public async Task<IActionResult> Edit(ClienteViewModel viewModel)
    {
        viewModel = await PopulateCrvs(viewModel);

        if(!ModelState.IsValid)
            return View(viewModel);

        var requestModel = new EditClienteViewModel
        {
            CoordenadorRegionalId = viewModel.CoordenadorRegionalId.Value,
            Endereco = viewModel.Endereco
        };

        var response = await _requestApiService.Request($"Cliente/Edit/{viewModel.Id}", Method.PUT, requestModel);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Cliente edited successfully!";
            return RedirectToAction("Index", "Cliente");
        }

        ViewBag.ErrorEdit = "Unexpected error!";

        return View(viewModel);
    }
    #endregion

    #region POST - Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ClaimsAuthorize(PermissionsType.Cliente, PermissionValue.Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
            return Json(new CustomResponse().WithError("Id is required"));

        try
        {
            var response = await _requestApiService.Request($"Cliente/Delete/{id}", Method.DELETE);
            if (response.IsSuccessStatusCode) {
                return Json(new CustomResponse().WithSuccess());
            }

            var customResponse = JsonHelper.JsonToObject<CustomResponse>(await response.Content.ReadAsStringAsync());

            return Json(new CustomResponse().WithErrors(customResponse));
        }
        catch (Exception) {
            return Json(new CustomResponse().WithError("Occurred a unexpected error!"));
        }
    }
    #endregion

    #region Private Methods

    #region Populate Crvs
    private async Task<ClienteViewModel> PopulateCrvs(ClienteViewModel viewModel)
    {
        var response = await _requestApiService.Request("CoordenadorRegional/GetAll", Method.GET);
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

    #endregion
}
