using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.DTOs.Produtos;

public class ProdutoDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Quantidade { get; set; }
    public Unidade Unidade { get; set; }
    public decimal Preco { get; set; }

    public static implicit operator ProdutoDTO(Produto produto)
    {
        return new ProdutoDTO
        {
            Id = produto.Id,
            Descricao = produto.Descricao,
            Quantidade = produto.Quantidade,
            Preco = produto.Preco,
            Unidade = produto.Unidade
        };
    }
}
