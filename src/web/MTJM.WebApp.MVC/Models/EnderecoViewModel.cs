using System.ComponentModel.DataAnnotations;

namespace MTJM.WebApp.MVC.Models;

public class EnderecoViewModel
{
    [StringLength(8, ErrorMessage = "Characters required lenght {1}", MinimumLength = 0)]
    [RegularExpression(@"\d{8}$", ErrorMessage = "{0} format invalid!")]
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
}