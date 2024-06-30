using System.ComponentModel.DataAnnotations;

namespace MTJM.WebApp.MVC.Models;

public class ClienteViewModel
{
    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(100, ErrorMessage = "Characters lenght not in {2} and {1}", MinimumLength = 5)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(14, ErrorMessage = "Characters required lenght {2}", MinimumLength = 14)]
    public string CNPJ { get; set; }
    public EnderecoViewModel Endereco { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(30, ErrorMessage = "Characters lenght not in {2} and {1}", MinimumLength = 5)]
    public string Username { get; set; }
}

public class EnderecoViewModel
{
    [StringLength(8, ErrorMessage = "Characters required lenght {1}", MinimumLength = 0)]
    [RegularExpression(@"\d{8}$", ErrorMessage = "{0} format invalid!")]
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
}