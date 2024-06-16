using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.Attributes;
using MTJM.API.DTOs.Produtos;
using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Permissions;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Controllers.Propostas;

[Route("api/[controller]")]
public class ProdutoController : BaseController
{
    #region Properties
    private readonly IProdutoRepository _produtoRepository;
    #endregion

    #region Constructors
    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    #endregion

    #region Public Methods

    #region Get All
    [HttpGet]
    [Route("GetAll")]
    [ClaimsAuthorize(nameof(PermissionsType.Produto), nameof(PermissionsValue.Read))]
    public IActionResult GetAll()
    {
        var responseDTO = new List<ProdutoDTO>();

        _produtoRepository.GetAll().ToList().ForEach(produto =>
        {
            ProdutoDTO p = produto;
            responseDTO.Add(p);
        });

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Get By Id
    [HttpGet]
    [Route("GetById/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Produto), nameof(PermissionsValue.Read))]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoRepository.GetById(id);

        if (produto is null)
        {
            AdicionaErros("Produto Not Found");
            return CustomResponse();
        }

        ProdutoDTO responseDTO = produto;

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("Create")]
    [ClaimsAuthorize(nameof(PermissionsType.Produto), nameof(PermissionsValue.Create))]
    public async Task<IActionResult> Create(RequestProdutoDTO requestDTO)
    {
        Produto produto = requestDTO;

        if (!produto.IsValid()) return CustomResponse(produto.ValidationResult);

        ProdutoDTO responseDTO = await _produtoRepository.Create(produto);

        return CustomResponse(responseDTO);
    }
    #endregion

    #region Edit
    [HttpPut]
    [Route("Edit/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Produto), nameof(PermissionsValue.Update))]
    public async Task<IActionResult> Edit(int id, RequestProdutoDTO requestDTO)
    {
        var produto = await _produtoRepository.GetById(id);

        if (produto is null)
        {
            AdicionaErros("Produto Not Found");
            return CustomResponse();
        }

        produto.Update(requestDTO);

        if (!produto.IsValid()) return CustomResponse(produto.ValidationResult);

        await _produtoRepository.Edit(produto);

        return CustomResponse();
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("Delete/{id:int}")]
    [ClaimsAuthorize(nameof(PermissionsType.Produto), nameof(PermissionsValue.Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        var produto = await _produtoRepository.GetById(id);

        if (produto is null)
        {
            AdicionaErros("Produto Not Found");
            return CustomResponse();
        }

        await _produtoRepository.Delete(id);

        return CustomResponse();
    }
    #endregion

    #endregion
}
