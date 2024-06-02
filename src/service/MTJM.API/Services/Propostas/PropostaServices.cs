using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Produtos;
using MTJM.API.DTOs.Propostas;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Propostas;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Services.Propostas;

public class PropostaServices : IPropostaServices
{
    #region Properties
    private readonly IPropostaRepository _propostaRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly ICoordenadorRegionalRepository _coordenadorRegionalRepository;
    private readonly IOrcamentistaRepository _orcamentistaRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IServicoRepository _servicoRepository;
    #endregion

    #region Constructor
    public PropostaServices(IPropostaRepository propostaRepository,
        IClienteRepository clienteRepository,
        ICoordenadorRegionalRepository coordenadorRegionalRepository,
        IOrcamentistaRepository orcamentistaRepository,
        IProdutoRepository produtoRepository,
        IServicoRepository servicoRepository)
    {
        _propostaRepository = propostaRepository;
        _clienteRepository = clienteRepository;
        _coordenadorRegionalRepository = coordenadorRegionalRepository;
        _orcamentistaRepository = orcamentistaRepository;
        _produtoRepository = produtoRepository;
        _servicoRepository = servicoRepository;
    }
    #endregion

    #region Methods

    #region Create Proposta
    public async Task<PropostaDTO> CreateProposta(CreatePropostaDTO requestDTO)
    {
        Proposta model = requestDTO;

        PropostaDTO responseDTO = model;

        if (!model.IsValid()) return responseDTO;


        if(!await ExistsCliente(requestDTO.ClienteId))
            responseDTO.AddError("Cliente Not Found");

        if(!await ExistsOrcamentista(requestDTO.OrcamentistaId))
            responseDTO.AddError("Orcamentista Not Found");

        if(!await ExistsCoordenadorRegional(requestDTO.CoordenadorRegionalId))
            responseDTO.AddError("Coordenador Regional Not Found");

        if(responseDTO.Errors.Any()) return responseDTO;

        model = await _propostaRepository.Create(model);
        responseDTO = model;

        return responseDTO;
    }
    #endregion

    #region Insert Produto Proposta
    public async Task<PropostaDTO> InsertProdutoProposta(PropostaProdutoDTO requestProdutoDTO)
    {
        var proposta = await _propostaRepository.GetByIdAllProdutosAndServicos(requestProdutoDTO.PropostaId);
        PropostaDTO responseDTO = new PropostaDTO();

        if (proposta is null)
            responseDTO.AddError("Proposta Not Found");

        var produto = await GetProduto(requestProdutoDTO.ProdutoId);

        if (produto is null)
            responseDTO.AddError("Produto Not Found");

        //if (proposta.PropostaProdutos.First(prod => prod.ProdutoId == produto.Id) is not null)
        //    responseDTO.AddError($"Produto {produto.Descricao} has already been inserted");

        if (responseDTO.Errors.Any())
            return responseDTO;

        proposta.AddProduto(CreatePropostaProduto(produto, requestProdutoDTO));

        await _propostaRepository.Edit(proposta);

        responseDTO = proposta;

        return responseDTO;
    }
    #endregion

    #endregion

    #region Private Methods
    private async Task<bool> ExistsCliente(int clienteId)
        => await _clienteRepository.GetById(clienteId) is null ? false : true;
    private async Task<bool> ExistsOrcamentista(int orcamentistaId)
        => await _orcamentistaRepository.GetById(orcamentistaId) is null ? false : true;
    private async Task<bool> ExistsCoordenadorRegional(int coordenadorRegionalId)
        => await _coordenadorRegionalRepository.GetById(coordenadorRegionalId) is null ? false : true;
    private async Task<Produto> GetProduto(int produtoId)
        => await _produtoRepository.GetById(produtoId);
    private PropostaProduto CreatePropostaProduto(Produto produto, PropostaProdutoDTO requestProdutoDTO)
    {
        var valorProduto = (decimal)(double.Parse(produto.Preco.ToString()) * ((requestProdutoDTO.Lucratividade / 100) + 1));
        return new PropostaProduto(requestProdutoDTO.PropostaId,
            produto.Id,
            requestProdutoDTO.Quantidade,
            valorProduto,
            produto.Descricao,
            requestProdutoDTO.Lucratividade);
    }
    #endregion
}
