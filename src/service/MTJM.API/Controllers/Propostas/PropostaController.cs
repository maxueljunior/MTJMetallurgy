using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Produtos;
using MTJM.API.DTOs.Propostas;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Propostas;
using MTJM.API.Models.Servicos;
using MTJM.API.Services.Propostas;

namespace MTJM.API.Controllers.Propostas;

[Route("api/[controller]")]
public class PropostaController : BaseController
{
    #region Properties
    private readonly IPropostaServices _propostaServices;
    #endregion

    #region Constructors
    public PropostaController(IPropostaServices propostaServices)
    {
        _propostaServices = propostaServices;
    }
    #endregion

    #region Methods

    #region POST - Create
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CreatePropostaDTO requestDTO)
    {
        var proposta = await _propostaServices.CreateProposta(requestDTO);

        return ValidAndReturn(proposta);
    }
    #endregion

    #region POST - Insert a Produto
    [HttpPost]
    [Route("InsertProduto")]
    public async Task<IActionResult> InsertProduto(CreatePropostaProdutoDTO requestProdutoDTO) => 
        ValidAndReturn(await _propostaServices.InsertProdutoProposta(requestProdutoDTO));
    #endregion

    #region POST - Insert a Servico
    [HttpPost]
    [Route("InsertServico")]
    public async Task<IActionResult> InsertServico(CreatePropostaServicoDTO requestServicoDTO) =>
        ValidAndReturn(await _propostaServices.InsertServicoProposta(requestServicoDTO));
    #endregion

    #region PUT - Edit Produto
    [HttpPut]
    [Route("EditProduto")]
    public async Task<IActionResult> EditProduto(CreatePropostaProdutoDTO requestProdutoDTO)
        => ValidAndReturn(await _propostaServices.UpdatePropostaProduto(requestProdutoDTO));
    #endregion

    #region PUT - Edit Servico
    [HttpPut]
    [Route("EditServico")]
    public async Task<IActionResult> EditServico(CreatePropostaServicoDTO requestServicoDTO)
        => ValidAndReturn(await _propostaServices.UpdatePropostaServico(requestServicoDTO));
    #endregion

    #region DELETE - Delete Produto
    [HttpDelete]
    [Route("DeleteProduto/{propostaId:int}/{produtoId:int}")]
    public async Task<IActionResult> DeleteProduto(int propostaId, int produtoId)
        => ValidAndReturnSuccess(await _propostaServices.DeletePropostaProduto(propostaId, produtoId));
    #endregion

    #endregion

    #region Private Methods
    private IActionResult ValidAndReturn(PropostaDTO proposta)
    {
        if (!proposta.ValidationResult.IsValid)
            return CustomResponse(proposta.ValidationResult);

        if (proposta.Errors.Any())
            return CustomResponse(proposta.Errors);

        return CustomResponse(proposta);
    }

    private IActionResult ValidAndReturnSuccess(PropostaDTO proposta)
    {
        if (!proposta.ValidationResult.IsValid)
            return CustomResponse(proposta.ValidationResult);

        if (proposta.Errors.Any())
            return CustomResponse(proposta.Errors);

        return CustomResponse();
    }
    #endregion
}
