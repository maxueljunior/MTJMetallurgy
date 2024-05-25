using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.Context;
using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Controllers.Servicos;

[Route("api/[controller]")]
public class ServicoController : BaseController
{
    #region Properties
    private readonly IServicoRepository _servicoRepository;
    #endregion

    #region Constructors
    public ServicoController(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        var responseDTO = new List<ServicoDTO>();

        _servicoRepository.GetAll().ToList().ForEach(servico =>
        {
            ServicoDTO s = servico;
            responseDTO.Add(s);
        });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var servico = await _servicoRepository.GetById(id);

        if (servico is null)
        {
            AdicionaErros("Servico Not Found");
            return CustomResponse();
        }

        ServicoDTO responseDTO = servico;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(RequestServicoDTO requestDTO)
    {
        Servico servico = requestDTO;

        if(!servico.IsValid()) return CustomResponse(servico.ValidationResult);

        ServicoDTO responseDTO = await _servicoRepository.Create(servico);

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    public async Task<IActionResult> Edit(int id, RequestServicoDTO requestDTO)
    {
        var servico = await _servicoRepository.GetById(id);

        if(servico is null)
        {
            AdicionaErros("Servico Not Found");
            return CustomResponse();
        }

        servico.Update(requestDTO);

        if(!servico.IsValid()) return CustomResponse(servico.ValidationResult);

        await _servicoRepository.Edit(servico);

        return CustomResponse();
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var servico = await _servicoRepository.GetById(id);

        if (servico is null)
        {
            AdicionaErros("Servico Not Found");
            return CustomResponse();
        }

        await _servicoRepository.Delete(id);

        return CustomResponse();
    }
    #endregion

    #endregion

}
