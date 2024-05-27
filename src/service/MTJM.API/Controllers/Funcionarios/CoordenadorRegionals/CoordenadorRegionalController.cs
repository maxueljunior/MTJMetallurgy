using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Controllers.Funcionarios.CoordenadorRegionals;

[Route("api/[controller]")]
public class CoordenadorRegionalController : BaseController
{
    #region Properties
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;

    #endregion

    #region Constructor
    public CoordenadorRegionalController(ICoordenadorRegionalRepository coordenadorRegionalRepository)
    {
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        var responseDTO = new List<CoordenadorRegionalDTO>();

        _coordenadorRegionalRepository.GetAll().ToList().ForEach(crv =>
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
    public async Task<IActionResult> Create(RequestCoordenadorRegionalDTO requestDTO)
    {
        CoordenadorRegional crv = requestDTO;

        if (!crv.IsValid()) return CustomResponse(crv.ValidationResult);

        CoordenadorRegionalDTO responseDTO = await _coordenadorRegionalRepository.Create(crv);

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int id, RequestCoordenadorRegionalDTO requestDTO)
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
