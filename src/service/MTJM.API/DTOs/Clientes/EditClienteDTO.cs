using MTJM.API.Models.Enderecos;

namespace MTJM.API.DTOs.Clientes;

public class EditClienteDTO
{
    public Endereco Endereco { get; set; }
    public int CoordenadorRegionalId { get; set; }
}
