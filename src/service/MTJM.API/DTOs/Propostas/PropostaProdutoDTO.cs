using MTJM.API.Models.Propostas;

namespace MTJM.API.DTOs.Propostas;

public class PropostaProdutoDTO { 
    public int PropostaId { get; set; }
    public int ProdutoId { get; set; }
    public string Descricao { get; set; }
    public double Quantidade { get; set; }
    public decimal Preco { get; set; }
    public double Lucratividade { get; set; }

    public static implicit operator PropostaProdutoDTO(PropostaProduto p)
    {
        return new PropostaProdutoDTO
        {
            PropostaId = p.PropostaId,
            ProdutoId = p.ProdutoId,
            Descricao = p.Descricao,
            Quantidade = p.Quantidade,
            Preco = p.Preco,
            Lucratividade = p.Lucratividade
        };
    }

    public static implicit operator PropostaProduto(PropostaProdutoDTO p) =>
        new PropostaProduto(p.PropostaId, p.ProdutoId, p.Quantidade, p.Preco, p.Descricao, p.Lucratividade);
}
