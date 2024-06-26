using System.ComponentModel.DataAnnotations;

namespace MTJM.WebApp.MVC.DTO;

public class EnderecoDTO
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }

    private EnderecoDTO() { }

    public EnderecoDTO(string cep, string logradouro, string bairro, string localidade)
    {
        Cep = cep;
        Logradouro = logradouro;
        Bairro = bairro;
        Localidade = localidade;
    }
}
