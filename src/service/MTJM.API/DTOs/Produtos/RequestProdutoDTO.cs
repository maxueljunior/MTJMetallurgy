using MTJM.API.Models.Produtos;

namespace MTJM.API.DTOs.Produtos;

public class RequestProdutoDTO
{
    public string Descricao { get; set; }
    public double Quantidade { get; set; }
    public Unidade Unidade { get; set; }
    public decimal Preco { get; set; }

    public static implicit operator Produto(RequestProdutoDTO dto) =>
        new Produto(dto.Descricao, dto.Quantidade, dto.Unidade, dto.Preco);
}
