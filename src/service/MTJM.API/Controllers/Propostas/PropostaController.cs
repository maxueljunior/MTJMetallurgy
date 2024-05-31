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
    [Route("InsertProduto/{propostaId:int}")]
    public async Task<IActionResult> InsertProduto(int propostaId, ProdutoDTO requestProdutoDTO) => 
        ValidAndReturn(await _propostaServices.InsertProdutoProposta(propostaId, requestProdutoDTO));
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
    #endregion
}
