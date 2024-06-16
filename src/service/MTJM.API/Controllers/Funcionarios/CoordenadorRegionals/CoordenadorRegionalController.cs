using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;
using MTJM.API.Events;
using MTJM.API.Listeners.Orcamentista;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Permissions;

namespace MTJM.API.Controllers.Funcionarios.CoordenadorRegionals;

[Route("api/[controller]")]
public class CoordenadorRegionalController : BaseController
{
    #region Properties
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    private readonly IDispatcher _dispatcher;
    #endregion

    #region Constructor
    public CoordenadorRegionalController(ICoordenadorRegionalRepository coordenadorRegionalRepository,
        IDispatcher dispatcher)
    {
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
        _dispatcher = dispatcher;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    [ClaimsAuthorize(nameof(PermissionsType.CRV), nameof(PermissionsValue.Read))]
    public IActionResult GetAll()
    {
        var responseDTO = new List<OrcamentistaDTO>();

        _coordenadorRegionalRepository.GetAll().ToList().ForEach(crv =>
        {
            OrcamentistaDTO p = crv;
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

        OrcamentistaDTO responseDTO = crv;

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

        OrcamentistaDTO responseDTO = await _coordenadorRegionalRepository.Create(crv);
        await _dispatcher.Publish(new FuncionarioCreatedEvent(crv.Nome, crv.Sobrenome));
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
        var crv = await _coordenadorRegionalRepository.GetById(id);

        if (crv is null)
        {
            AdicionaErros("CoordenadorRegional Not Found");
            return CustomResponse();
        }

        await _coordenadorRegionalRepository.Delete(id);

        return CustomResponse();
    }
    #endregion

    #endregion
}
