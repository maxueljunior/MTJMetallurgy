using MTJM.API.Models.Propostas;

namespace MTJM.API.DTOs.Propostas;

public class CreatePropostaDTO
{
    public int ClienteId { get; set; }
    public int CoordenadorRegionalId { get; set; }
    public int OrcamentistaId { get; set; }

    public static implicit operator Proposta(CreatePropostaDTO requestPropostaDTO)
        => new Proposta(requestPropostaDTO.ClienteId, requestPropostaDTO.CoordenadorRegionalId, requestPropostaDTO.OrcamentistaId);
}
