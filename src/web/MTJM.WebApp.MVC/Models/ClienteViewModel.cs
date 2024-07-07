using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTJM.WebApp.MVC.Models;

public class ClienteViewModel
{
    public int Id { get; set; }

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

    [Required(ErrorMessage = "{0} is required.")]
    public int? CoordenadorRegionalId { get; set; }

    public string CoordenadorRegional { get; set; }

    [JsonIgnore]
    public IEnumerable<SelectListItem> crvs { get; set; }
}
