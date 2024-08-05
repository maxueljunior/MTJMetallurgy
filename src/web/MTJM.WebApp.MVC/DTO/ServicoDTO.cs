namespace MTJM.WebApp.MVC.DTO;

public class ServicoDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Horas { get; set; }
    public decimal PrecoPorHora { get; set; }
    public string Unidade { get; set; }
}
