using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Produtos;
using MTJM.API.DTOs.Propostas;

namespace MTJM.API.Services.Propostas;

public interface IPropostaServices
{
    Task<PropostaDTO> CreateProposta(CreatePropostaDTO requestDTO);
    Task<PropostaDTO> InsertProdutoProposta(CreatePropostaProdutoDTO requestProdutoDTO);
    Task<PropostaDTO> InsertServicoProposta(CreatePropostaServicoDTO requestServicoDTO);
}
