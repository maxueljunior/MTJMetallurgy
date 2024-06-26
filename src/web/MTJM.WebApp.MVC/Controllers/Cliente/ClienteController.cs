using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTJM.WebApp.MVC.DTO;
using MTJM.WebApp.MVC.Services;
using System.Text.Json;

namespace MTJM.WebApp.MVC.Controllers.Cliente;

[Authorize]
public class ClienteController : Controller
{
    private readonly IRequestApiService _requestApiService;

    public ClienteController(IRequestApiService requestApiService)
    {
        _requestApiService = requestApiService;
    }

    public IActionResult Index()
    {
        return View();
    }

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
}
