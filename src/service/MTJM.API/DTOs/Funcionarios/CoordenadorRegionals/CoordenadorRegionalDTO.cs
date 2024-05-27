using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;

public class CoordenadorRegionalDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public Cargo Cargo { get; set; }
    public int TempoDeCasa { get; set; }

    public static implicit operator CoordenadorRegionalDTO(CoordenadorRegional c)
    {
        return new CoordenadorRegionalDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Salario = c.Salario,
            Sobrenome = c.Sobrenome,
            DataContratacao = c.DataContratacao,
            Endereco = c.Endereco,
            Cargo = c.Cargo,
            TempoDeCasa = c.TempoDeCasa
        };
    }
}
