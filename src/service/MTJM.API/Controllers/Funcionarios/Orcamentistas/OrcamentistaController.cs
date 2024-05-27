using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTJM.API.DTOs.Funcionarios.Orcamentistas;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Controllers.Funcionarios.Orcamentistas;

[Route("api/[controller]")]
public class OrcamentistaController : BaseController
{
    #region Properties
    private readonly IOrcamentistaRepository _orcamentistaRepository;
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    #endregion

    #region Constructor
    public OrcamentistaController(IOrcamentistaRepository orcamentistaRepository,
        ICoordenadorRegionalRepository coordenadorRegionalRepository)
    {
        _orcamentistaRepository = orcamentistaRepository;
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
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

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
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
