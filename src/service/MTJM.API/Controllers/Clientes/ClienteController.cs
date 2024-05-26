using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Clientes;
using MTJM.API.Models.Clientes;

namespace MTJM.API.Controllers.Clientes;

[Route("api/[controller]")]
public class ClienteController : BaseController
{
    #region Properties
    private readonly IClienteRepository _clienteRepository;

    #endregion

    #region Constructor
    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        var responseDTO = new List<ClienteDTO>();

        _clienteRepository.GetAll().ToList().ForEach(cliente =>
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
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteRepository.GetById(id);

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
    public async Task<IActionResult> Create(RequestClienteDTO requestDTO)
    {
        Cliente cliente = requestDTO;

        if (!cliente.IsValid()) return CustomResponse(cliente.ValidationResult);

        ClienteDTO responseDTO = await _clienteRepository.Create(cliente);

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
