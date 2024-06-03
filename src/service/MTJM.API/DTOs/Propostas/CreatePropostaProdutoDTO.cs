namespace MTJM.API.DTOs.Propostas;

public class CreatePropostaProdutoDTO
{
    public int PropostaId { get; set; }
    public int ProdutoId { get; set; }
    public double Quantidade { get; set; }
    public double Lucratividade { get; set; }
}
