using System.ComponentModel.DataAnnotations;

namespace MTJM.API.Models.Enderecos;

public class Endereco
{
    [StringLength(8)]
    public string Cep { get; private set; }

    [StringLength(100)]
    public string Logradouro { get; private set; }

    [StringLength(100)]
    public string Bairro { get; private set; }

    [StringLength(100)]
    public string Localidade { get; private set; }

    private Endereco() { }

    public Endereco(string cep, string logradouro, string bairro, string localidade)
    {
        Cep = cep;
        Logradouro = logradouro;
        Bairro = bairro;
        Localidade = localidade;
    }
}
