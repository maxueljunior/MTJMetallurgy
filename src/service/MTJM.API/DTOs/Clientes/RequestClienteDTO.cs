using MTJM.API.DTOs.Produtos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Produtos;

namespace MTJM.API.DTOs.Clientes;

public class RequestClienteDTO
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public Endereco Endereco { get; set; }
    public string? Username { get; set; }
    public int CoordenadorRegionalId { get; set; }

    public static implicit operator Cliente(RequestClienteDTO dto) =>
    new Cliente(dto.Nome, dto.Cnpj, dto.Endereco, dto.CoordenadorRegionalId);
}
