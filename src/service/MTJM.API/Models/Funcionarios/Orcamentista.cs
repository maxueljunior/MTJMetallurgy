using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios
{
    public class Orcamentista : Funcionario
    {
        public ICollection<Proposta> Propostas { get; set; }
        public int CoordenadorRegionalId { get; set; } // Required foreign key property
        public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
    }
}
