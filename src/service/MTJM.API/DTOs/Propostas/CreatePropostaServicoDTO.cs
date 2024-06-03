namespace MTJM.API.DTOs.Propostas;

public class CreatePropostaServicoDTO
{
    public int PropostaId { get; set; }
    public int ServicoId { get; set; }
    public double Lucratividade { get; set; }
}
