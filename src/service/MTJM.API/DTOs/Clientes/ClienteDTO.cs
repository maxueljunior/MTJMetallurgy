using MTJM.API.DTOs.Produtos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Produtos;

namespace MTJM.API.DTOs.Clientes;

public class ClienteDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public Endereco Endereco { get; set; }
    public bool Ativo { get; set; }
    public int? CoordenadorRegionalId { get; set; }
    public string CoordenadorRegional {  get; set; }
    public string Username { get; set; }

    public static implicit operator ClienteDTO(Cliente c)
    {
        return new ClienteDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Cnpj = c.Cnpj,
            Endereco = c.Endereco,
            Ativo = c.Ativo,
            CoordenadorRegionalId = c.CoordenadorRegionalId,
            CoordenadorRegional = string.Concat(c.CoordenadorRegional?.Nome, " ", c.CoordenadorRegional?.Sobrenome),
            Username = c.UserAccount?.UserName
        };
    }
}
