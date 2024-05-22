using MTJM.API.Models.Servicos;

namespace MTJM.API.DTOs.Servicos;

public class ServicoDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Horas { get; set; }
    public decimal PrecoPorHora { get; set; }
    public string Unidade { get; set; }

    public static implicit operator ServicoDTO(Servico servico)
    {
        return new ServicoDTO
        {
            Id = servico.Id,
            Descricao = servico.Descricao,
            Horas = servico.Horas,
            PrecoPorHora = servico.PrecoPorHora,
            Unidade = servico.Unidade
        };
    }
}
