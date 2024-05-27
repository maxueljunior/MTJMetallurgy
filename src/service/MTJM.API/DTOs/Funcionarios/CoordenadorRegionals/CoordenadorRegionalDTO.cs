using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;

public class OrcamentistaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public int TempoDeCasa { get; set; }

    public static implicit operator OrcamentistaDTO(CoordenadorRegional c)
    {
        return new OrcamentistaDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Salario = c.Salario,
            Sobrenome = c.Sobrenome,
            DataContratacao = c.DataContratacao,
            Endereco = c.Endereco,
            TempoDeCasa = c.TempoDeCasa
        };
    }
}
