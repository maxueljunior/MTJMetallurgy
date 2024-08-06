using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTJM.WebApp.MVC.Models;

public class ServicosViewModel
{
    [Required(ErrorMessage = "{0} is required")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0d, 100000d, ErrorMessage = "{0} minimum is {1}")]
    public decimal? Horas { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0d, 100000d, ErrorMessage = "{0} minimum is {1}")]
    [DisplayName("Preco Por Hora")]
    public decimal? PrecoPorHora { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public string Unidade { get; set; }
}
