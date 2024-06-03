using MTJM.API.Models.Propostas;

namespace MTJM.API.DTOs.Propostas;

public class PropostaServicoDTO
{
    public int PropostaId { get; set; }
    public int ServicoId { get; set; }
    public string Descricao { get; set; }
    public decimal Horas { get; set; }
    public decimal PrecoPorHora { get; set; }
    public double Lucratividade { get; set; }

    public static implicit operator PropostaServicoDTO(PropostaServico ps)
    {
        return new PropostaServicoDTO
        {
            PropostaId = ps.PropostaId,
            ServicoId = ps.ServicoId,
            Descricao = ps.Descricao,
            Horas = ps.Horas,
            PrecoPorHora = ps.PrecoPorHora,
            Lucratividade = ps.Lucratividade
        };
    }

    public static implicit operator PropostaServico(PropostaServicoDTO p) =>
        new PropostaServico(p.PropostaId, p.ServicoId, p.Descricao, p.PrecoPorHora, p.Horas, p.Lucratividade);
}
