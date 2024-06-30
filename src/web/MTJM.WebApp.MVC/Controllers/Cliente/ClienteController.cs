using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
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
    public IActionResult Create()
    {
        return View();
    }
    #endregion

    #region POST - Create
    [HttpPost]
    public async Task<IActionResult> Create(ClienteViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var response = await _requestApiService.Request("Cliente/Create", Method.POST, viewModel);

        if (response.IsSuccessStatusCode) { 
            TempData["CreateSuccess"] = "Cliente create successfully!";
            return RedirectToAction("Index", "Cliente");
        }

        ViewBag.ErrorCreate = "Unexpected error!";
        return View(viewModel);
    }
    #endregion
}
