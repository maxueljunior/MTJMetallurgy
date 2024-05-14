using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Servicos
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Horas { get; set; }
        public decimal PrecoPorHora { get; set; }
        public string Unidade { get; set; }
        public ICollection<Proposta> Propostas { get; set; }
    }
}
