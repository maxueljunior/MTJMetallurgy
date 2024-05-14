using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Models.Propostas
{
    public class Proposta
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public int Prazo { get; set; }
        public Status Status { get; set; }
        public string CondicaoPagamento { get; set; }
        public int ClienteId { get; set; } // Required foreign key property
        public Cliente Cliente { get; set; } // Required reference navigation to principal
        public int CoordenadorRegionalId { get; set; } // Required foreign key property
        public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
        public int OrcamentistaId { get; set; } // Required foreign key property
        public Orcamentista Orcamentista { get; set; } // Required reference navigation to principal
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Servico> Servicos { get; set; }

    }
}
