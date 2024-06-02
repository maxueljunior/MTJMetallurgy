using MTJM.API.Models.Produtos;
using System.ComponentModel.DataAnnotations;

namespace MTJM.API.Models.Propostas;

public class PropostaProduto
{
    #region Properties
    public int PropostaId { get; private set; }
    public Proposta Proposta { get; private set; }
    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public string Descricao { get; private set; }
    public double Quantidade { get; private set; }
    public decimal Preco { get; private set; }
    public double Lucratividade { get; private set; }
    #endregion

    #region Constructors
    private PropostaProduto() { }

    public PropostaProduto(int propostaId, int produtoId, double quantidade, decimal preco, string descricao, double lucratividade)
    {
        PropostaId = propostaId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
        Descricao = descricao;
        Lucratividade = lucratividade;
    }
    #endregion
}
