using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;
using MTJM.API.Events;
using MTJM.API.Listeners.Orcamentista;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Permissions;
using MTJM.API.Services.Auth;

namespace MTJM.API.Controllers.Funcionarios.CoordenadorRegionals;

[Route("api/[controller]")]
public class CoordenadorRegionalController : BaseController
{
    #region Properties
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    private readonly IDispatcher _dispatcher;
    private readonly IAuthServices _authServices;
    #endregion

    #region Constructor
    public CoordenadorRegionalController(ICoordenadorRegionalRepository coordenadorRegionalRepository,
        IDispatcher dispatcher,
        IAuthServices authServices)
    {
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
        _dispatcher = dispatcher;
        _authServices = authServices;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Read))]
    public IActionResult GetAll()
    {
        var responseDTO = new List<CoordenadorRegionalDTO>();

        _coordenadorRegionalRepository.GetAll()
            .Include(c => c.Orcamentista)
            .Include(c => c.Clientes)
            .Where(c => c.Ativo)
            .ToList().ForEach(crv =>
        {
            CoordenadorRegionalDTO p = crv;
            responseDTO.Add(p);
        });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get All Without Orcamentista
    [HttpGet]
    [Route("GetAllWithoutOrcamentista")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Read))]
    public IActionResult GetAllWithoutOrcamentista([FromQuery] int orcamentistaId = 0)
    {
        var responseDTO = new List<CoordenadorRegionalDTO>();

        _coordenadorRegionalRepository.GetAll()
            .Include(c => c.Orcamentista)
            .Where(c => c.Ativo &&
                        ( c.Orcamentista == null || c.Orcamentista.Id == orcamentistaId ))
            .ToList()
            .ForEach(crv =>
            {
                CoordenadorRegionalDTO p = crv;
                responseDTO.Add(p);
            });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Read))]
    public async Task<IActionResult> GetById(int id)
    {
        var crv = await _coordenadorRegionalRepository.GetById(id);

        if (crv is null)
        {
            AdicionaErros("CoordenadorRegional Not Found");
            return CustomResponse();
        }

        CoordenadorRegionalDTO responseDTO = crv;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Create))]
    public async Task<IActionResult> Create(RequestOrcamentistaDTO requestDTO)
    {
        CoordenadorRegional crv = requestDTO;

        if (!crv.IsValid()) return CustomResponse(crv.ValidationResult);

        await _dispatcher.Publish(new FuncionarioCreatedEvent(crv.Nome, crv.Sobrenome));

        var user = await _authServices.GetUser(string.Concat(crv.Nome.ToLower(), ".", crv.Sobrenome.ToLower()));

        if (!string.IsNullOrEmpty(user.Id))
            crv.SetUserAccount(user.Id);

        CoordenadorRegionalDTO responseDTO = await _coordenadorRegionalRepository.Create(crv);

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Update))]
    public async Task<IActionResult> Edit(int id, RequestOrcamentistaDTO requestDTO)
    {
        var crv = await _coordenadorRegionalRepository.GetById(id);

        if (crv is null)
        {
            AdicionaErros("CoordenadorRegional Not Found");
            return CustomResponse();
        }

        crv.Update(requestDTO);

        if (!crv.IsValid()) return CustomResponse(crv.ValidationResult);

        await _coordenadorRegionalRepository.Edit(crv);

        return CustomResponse();
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("Delete/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Delete))]
    public async Task<IActionResult> Delete(int id)
    {

        var crv = await _coordenadorRegionalRepository.GetAll()
            .Where(c => c.Id == id)
            .Include(c => c.Orcamentista)
            .Include(c => c.Clientes)
            .FirstOrDefaultAsync();

        if (crv is null)
        {
            AdicionaErros("CoordenadorRegional Not Found");
            return CustomResponse();
        }

        crv.SetActive(false);
        crv.Orcamentista?.RemoveCoordenadorRegional();

        foreach (var cliente in crv.Clientes) {
            cliente.RemoveCoordenadorRegional();
        }

        await _coordenadorRegionalRepository.Edit(crv);

        return CustomResponse();
    }
    #endregion

    #endregion
}
