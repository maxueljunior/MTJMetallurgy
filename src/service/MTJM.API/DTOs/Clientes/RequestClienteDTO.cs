using MTJM.API.DTOs.Produtos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Produtos;

namespace MTJM.API.DTOs.Clientes;

public class RequestCoordenadorRegionalDTO
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public Endereco Endereco { get; set; }

    public static implicit operator Cliente(RequestCoordenadorRegionalDTO dto) =>
    new Cliente(dto.Nome, dto.Cnpj, dto.Endereco);
}
