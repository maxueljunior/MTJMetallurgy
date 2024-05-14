using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
        public int CoordenadorRegionalId { get; set; } // Required foreign key property
        public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
        public ICollection<Proposta> Propostas { get; set; }
    }
}
