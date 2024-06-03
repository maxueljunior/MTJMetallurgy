using MTJM.API.Models.Servicos;

namespace MTJM.API.Models.Propostas;

public class PropostaServico
{
    #region Properties
    public int PropostaId { get; private set; }
    public Proposta Proposta { get; private set; }
    public int ServicoId { get; private set; }
    public Servico Servico { get; private set; }
    public string Descricao { get; private set; }
    public decimal PrecoPorHora { get; private set; }
    public decimal Horas { get; private set; }
    public double Lucratividade { get; private set; }
    #endregion

    #region Constructors
    private PropostaServico() { }

    public PropostaServico(int propostaId,
        int servicoId,
        string descricao,
        decimal precoPorHora,
        decimal horas,
        double lucratividade)
    {
        PropostaId = propostaId;
        ServicoId = servicoId;
        Descricao = descricao;
        PrecoPorHora = precoPorHora;
        Horas = horas;
        Lucratividade = lucratividade;
    }
    #endregion
}
