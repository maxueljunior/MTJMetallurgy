using FluentValidation;
using MTJM.API.Models.Enderecos;

namespace MTJM.API.Models.Funcionarios;

public class Funcionario : Base
{
    #region Properties
    public const decimal MINIMUM_SALARY = 990.00m;
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

    #region Constructor
    protected Funcionario() { }

    public Funcionario(string nome, string sobrenome, DateTime dataContratacao, decimal salario, Endereco endereco, Cargo cargo)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        DataContratacao = dataContratacao;
        Salario = salario;
        Endereco = endereco;
        Cargo = cargo;
        SetActive(true);
    }
    #endregion

    #region Methods
    protected void SetActive(bool ativo) => Ativo = ativo;
    #endregion
}

public class FuncionarioValidator : AbstractValidator<Funcionario>
{
    public FuncionarioValidator()
    {
        RuleFor(f => f.Nome)
            .NotEmpty()
            .WithMessage("Nome is required.");

        RuleFor(f => f.Sobrenome)
            .NotEmpty()
            .WithMessage("Sobrenome is required.");

        RuleFor(f => f.Salario)
            .GreaterThan(Funcionario.MINIMUM_SALARY)
            .WithMessage($"Salary minium is {Funcionario.MINIMUM_SALARY}");
    }
}