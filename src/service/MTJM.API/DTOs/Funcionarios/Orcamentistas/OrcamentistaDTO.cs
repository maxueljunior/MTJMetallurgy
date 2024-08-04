using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.Orcamentistas;

public class OrcamentistaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public int TempoDeCasa { get; set; }
    public int CoordenadorRegionalId { get; set; }
    public string CoordenadorRegional { get; set; }

    public static implicit operator OrcamentistaDTO(Orcamentista o)
    {
        return new OrcamentistaDTO
        {
            Id = o.Id,
            Nome = o.Nome,
            Salario = o.Salario,
            Sobrenome = o.Sobrenome,
            DataContratacao = o.DataContratacao,
            Endereco = o.Endereco,
            TempoDeCasa = o.TempoDeCasa,
            CoordenadorRegionalId = o.CoordenadorRegionalId ?? 0,
            CoordenadorRegional = o.CoordenadorRegional is not null ? string.Concat(o.CoordenadorRegional.Nome, " ", o.CoordenadorRegional.Sobrenome) : string.Empty
        };
    }
}
