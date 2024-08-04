namespace MTJM.WebApp.MVC.DTO;

public class OrcamentistaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public EnderecoDTO Endereco { get; set; }
    public int TempoDeCasa { get; set; }
    public int CoordenadorRegionalId { get; set; }
    public string CoordenadorRegional { get; set; }
}
