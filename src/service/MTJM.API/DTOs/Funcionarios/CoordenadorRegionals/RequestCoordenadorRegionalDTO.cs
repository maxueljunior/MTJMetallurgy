using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;

public class RequestCoordenadorRegionalDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public Cargo Cargo { get; set; }

    public static implicit operator CoordenadorRegional(RequestCoordenadorRegionalDTO dto) =>
    new CoordenadorRegional(dto.Nome, dto.Sobrenome, dto.DataContratacao, dto.Salario, dto.Endereco, dto.Cargo);
}
