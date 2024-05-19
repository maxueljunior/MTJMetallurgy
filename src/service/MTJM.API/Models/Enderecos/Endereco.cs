using System.ComponentModel.DataAnnotations;

namespace MTJM.API.Models.Enderecos
{
    public class Endereco
    {
        [StringLength(8)]
        public string Cep { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }

        [StringLength(100)]
        public string Bairro { get; set; }

        [StringLength(100)]
        public string Localidade { get; set; }
    }
}
