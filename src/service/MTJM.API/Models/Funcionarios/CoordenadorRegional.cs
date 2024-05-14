using MTJM.API.Models.Clientes;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios
{
    public class CoordenadorRegional : Funcionario
    {
        public ICollection<Proposta> Propostas { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public Orcamentista Orcamentista { get; set; }
    }
}
