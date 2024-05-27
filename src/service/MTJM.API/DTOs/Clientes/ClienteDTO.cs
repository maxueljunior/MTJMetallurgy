using MTJM.API.DTOs.Produtos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Produtos;

namespace MTJM.API.DTOs.Clientes;

public class CoordenadorRegionalDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public Endereco Endereco { get; set; }
    public bool Ativo { get; set; }
    public int? CoordenadorRegionalId { get; set; }

    public static implicit operator CoordenadorRegionalDTO(Cliente c)
    {
        return new CoordenadorRegionalDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Cnpj = c.Cnpj,
            Endereco = c.Endereco,
            Ativo = c.Ativo,
            CoordenadorRegionalId = c.CoordenadorRegionalId
        };
    }
}
