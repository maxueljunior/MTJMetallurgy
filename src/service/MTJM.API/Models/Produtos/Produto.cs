using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Produtos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public Unidade Unidade { get; set; }
        public decimal Preco { get; set; }
        public ICollection<Proposta> Propostas { get; set; }
    }
}
