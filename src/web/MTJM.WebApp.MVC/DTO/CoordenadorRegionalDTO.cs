namespace MTJM.WebApp.MVC.DTO;

public class CoordenadorRegionalDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public EnderecoDTO Endereco { get; set; }
    public int TempoDeCasa { get; set; }
}
