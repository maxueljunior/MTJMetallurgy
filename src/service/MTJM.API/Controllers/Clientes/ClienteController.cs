using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Clientes;
using MTJM.API.Events;
using MTJM.API.Events.Cliente;
using MTJM.API.Models.Clientes;

namespace MTJM.API.Controllers.Clientes;

[Route("api/[controller]")]
public class ClienteController : BaseController
{
    #region Properties
    private readonly IClienteRepository _clienteRepository;
    private readonly IDispatcher _dispatcher;
    #endregion

    #region Constructor
    public ClienteController(IClienteRepository clienteRepository,
        IDispatcher dispatcher)
    {
        _clienteRepository = clienteRepository;
        _dispatcher = dispatcher;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        var responseDTO = new List<CoordenadorRegionalDTO>();

        _clienteRepository.GetAll().ToList().ForEach(cliente =>
        {
            CoordenadorRegionalDTO p = cliente;
            responseDTO.Add(p);
        });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteRepository.GetById(id);

        if (cliente is null)
        {
            AdicionaErros("Cliente Not Found");
            return CustomResponse();
        }

        CoordenadorRegionalDTO responseDTO = cliente;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(RequestClienteDTO requestDTO)
    {
        Cliente cliente = requestDTO;

        if (!cliente.IsValid()) return CustomResponse(cliente.ValidationResult);

        if (string.IsNullOrEmpty(requestDTO.Username))
        {
            AdicionaErros("Username is required!");
            return CustomResponse();
        }

        CoordenadorRegionalDTO responseDTO = await _clienteRepository.Create(cliente);

        await _dispatcher.Publish(new ClienteCreatedEvent(requestDTO.Username));

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int id, RequestClienteDTO requestDTO)
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
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _clienteRepository.GetById(id);

        if (cliente is null)
        {
            AdicionaErros("Cliente Not Found");
            return CustomResponse();
        }

        await _clienteRepository.Delete(id);

        return CustomResponse();
    }
    #endregion

    #endregion
}
