using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.Orcamentistas;

public class RequestOrcamentistaDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public int CoordenadorRegionalId { get; set; }

    public static implicit operator Orcamentista(RequestOrcamentistaDTO dto) =>
    new Orcamentista(dto.Nome, dto.Sobrenome, dto.DataContratacao, dto.Salario, dto.Endereco, dto.CoordenadorRegionalId);
}
