using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MTJM.WebApp.MVC.Models.Funcionarios;

public class CoordenadorRegionalViewModel
{
    [Required(ErrorMessage = "{0} is required.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Data Contratação")]
    public DateTime? DataContratacao { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [Range(990d, 100000d, ErrorMessage = "Minimum {0} is {1}")]
    public decimal? Salario { get; set; }
    public EnderecoViewModel Endereco { get; set; }
}
