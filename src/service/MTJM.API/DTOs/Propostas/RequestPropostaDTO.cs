using MTJM.API.Models.Propostas;

namespace MTJM.API.DTOs.Propostas;

public class RequestPropostaDTO
{
    public int ClienteId { get; set; }
    public int CoordenadorRegionalId { get; set; }
    public int OrcamentistaId { get; set; }
}
