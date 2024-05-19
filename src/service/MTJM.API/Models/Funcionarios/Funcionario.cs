using MTJM.API.Models.Enderecos;

namespace MTJM.API.Models.Funcionarios;

public class Funcionario
{
    #region Properties
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }
    public Cargo Cargo { get; set; }
    public bool Ativo { get; set; }
    public int TempoDeCasa
    {
        get
        {
            return DateTime.Now.Year - this.DataContratacao.Year;
        }
    }
    #endregion

    #region Methods

    #endregion
}
