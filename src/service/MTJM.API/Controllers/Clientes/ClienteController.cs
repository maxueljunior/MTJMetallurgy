using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Clientes;
using MTJM.API.Events;
using MTJM.API.Events.Cliente;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Permissions;
using MTJM.API.Services.Auth;

namespace MTJM.API.Controllers.Clientes;

[Route("api/[controller]")]
public class ClienteController : BaseController
{
    #region Properties
    private readonly IClienteRepository _clienteRepository;
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    private readonly IDispatcher _dispatcher;
    private readonly IAuthServices _authServices;
    #endregion

    #region Constructor
    public ClienteController(IClienteRepository clienteRepository,
        IDispatcher dispatcher,
        IAuthServices authServices,
        ICoordenadorRegionalRepository coordenadorRegionalRepository)
    {
        _clienteRepository = clienteRepository;
        _dispatcher = dispatcher;
        _authServices = authServices;
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    [ClaimsAuthorize(nameof(PermissionsType.Cliente), nameof(PermissionsValue.Read))]
    public IActionResult GetAll()
    {
        var responseDTO = new List<ClienteDTO>();

        _clienteRepository.GetAll()
            .Where(c => c.Ativo)
            .Include(c => c.CoordenadorRegional)
            .ToList()
            .ForEach(cliente =>
            {
                ClienteDTO p = cliente;
                responseDTO.Add(p);
            });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Cliente), nameof(PermissionsValue.Read))]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = _clienteRepository.GetAll()
            .Where(c => c.Id == id && c.Ativo)
            .Include(c => c.CoordenadorRegional)
            .Include(c => c.UserAccount)
            .FirstOrDefault();

        if (cliente is null)
        {
            AdicionaErros("Cliente Not Found");
            return CustomResponse();
        }

        ClienteDTO responseDTO = cliente;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    [ClaimsAuthorize(nameof(PermissionsType.Cliente), nameof(PermissionsValue.Create))]
    public async Task<IActionResult> Create(RequestClienteDTO requestDTO)
    {
        Cliente cliente = requestDTO;

        if (!cliente.IsValid()) return CustomResponse(cliente.ValidationResult);

        if (string.IsNullOrEmpty(requestDTO.Username))
        {
            AdicionaErros("Username is required!");
            return CustomResponse();
        }

        if (await _coordenadorRegionalRepository.GetById(requestDTO.CoordenadorRegionalId) is null)
        {
            AdicionaErros("Coordenador Regional Not Found!");
            return CustomResponse();
        }


        await _dispatcher.Publish(new ClienteCreatedEvent(requestDTO.Username));

        var user = await _authServices.GetUser(requestDTO.Username);
        cliente.UserAccountId = user.Id;
        ClienteDTO responseDTO = await _clienteRepository.Create(cliente);

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Cliente), nameof(PermissionsValue.Update))]
    public async Task<IActionResult> Edit(int id, EditClienteDTO requestDTO)
    {
        var cliente = await _clienteRepository.GetById(id);

        if (cliente is null)
        {
            AdicionaErros("Cliente Not Found");
            return CustomResponse();
        }

        cliente.Update(requestDTO);

        if (!cliente.IsValid()) return CustomResponse(cliente.ValidationResult);

        await _clienteRepository.Edit(cliente);

        return CustomResponse();
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("Delete/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Cliente), nameof(PermissionsValue.Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _clienteRepository.GetById(id);

        if (cliente is null)
        {
            AdicionaErros("Cliente Not Found");
            return CustomResponse();
        }

        cliente.SetActive(false);

        await _clienteRepository.Edit(cliente);

        return CustomResponse();
    }
    #endregion

    #endregion
}
