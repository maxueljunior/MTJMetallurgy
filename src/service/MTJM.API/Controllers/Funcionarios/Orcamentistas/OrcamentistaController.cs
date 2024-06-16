using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Funcionarios.Orcamentistas;
using MTJM.API.Events;
using MTJM.API.Listeners.Orcamentista;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Permissions;

namespace MTJM.API.Controllers.Funcionarios.Orcamentistas;

[Route("api/[controller]")]
public class OrcamentistaController : BaseController
{
    #region Properties
    private readonly IOrcamentistaRepository _orcamentistaRepository;
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    private readonly IDispatcher _dispatcher;
    #endregion

    #region Constructor
    public OrcamentistaController(IOrcamentistaRepository orcamentistaRepository,
        ICoordenadorRegionalRepository coordenadorRegionalRepository,
        IDispatcher dispatcher = null)
    {
        _orcamentistaRepository = orcamentistaRepository;
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
        _dispatcher = dispatcher;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    [ClaimsAuthorize(nameof(PermissionsType.Orcamentista), nameof(PermissionsValue.Read))]
    public IActionResult GetAll()
    {
        var responseDTO = new List<OrcamentistaDTO>();

        _orcamentistaRepository.GetAll().ToList().ForEach(orcamentista =>
        {
            OrcamentistaDTO p = orcamentista;
            responseDTO.Add(p);
        });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Orcamentista), nameof(PermissionsValue.Read))]
    public async Task<IActionResult> GetById(int id)
    {
        var orcamentista = await _orcamentistaRepository.GetById(id);

        if (orcamentista is null)
        {
            AdicionaErros("Orcamentista Not Found");
            return CustomResponse();
        }

        OrcamentistaDTO responseDTO = orcamentista;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    [ClaimsAuthorize(nameof(PermissionsType.Orcamentista), nameof(PermissionsValue.Create))]
    public async Task<IActionResult> Create(RequestOrcamentistaDTO requestDTO)
    {
        Orcamentista orcamentista = requestDTO;

        if (!orcamentista.IsValid()) return CustomResponse(orcamentista.ValidationResult);

        CoordenadorRegional crv = await _coordenadorRegionalRepository.GetAll()
            .Include(c => c.Orcamentista)
            .FirstOrDefaultAsync(c => c.Id == requestDTO.CoordenadorRegionalId);

        if (crv is null) {
            AdicionaErros("Coordenador Regional Not Found");
            return CustomResponse();
        }

        if (crv.Orcamentista is not null)
        {
            AdicionaErros("Coordenador Regional já possui Orçamentista");
            return CustomResponse();
        }

        OrcamentistaDTO responseDTO = await _orcamentistaRepository.Create(orcamentista);
        await _dispatcher.Publish(new FuncionarioCreatedEvent(requestDTO.Nome, requestDTO.Sobrenome));

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Orcamentista), nameof(PermissionsValue.Update))]
    public async Task<IActionResult> Edit(int id, RequestOrcamentistaDTO requestDTO)
    {
        var orcamentista = await _orcamentistaRepository.GetById(id);

        if (orcamentista is null)
        {
            AdicionaErros("Orcamentista Not Found");
            return CustomResponse();
        }

        orcamentista.Update(requestDTO);

        if (!orcamentista.IsValid()) return CustomResponse(orcamentista.ValidationResult);

        await _orcamentistaRepository.Edit(orcamentista);

        return CustomResponse();
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("Delete/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Orcamentista), nameof(PermissionsValue.Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        var orcamentista = await _orcamentistaRepository.GetById(id);

        if (orcamentista is null)
        {
            AdicionaErros("Orcamentista Not Found");
            return CustomResponse();
        }

        await _orcamentistaRepository.Delete(id);

        return CustomResponse();
    }
    #endregion

    #endregion
}
