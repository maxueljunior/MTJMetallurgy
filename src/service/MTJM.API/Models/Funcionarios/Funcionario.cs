using FluentValidation;
using MTJM.API.Models.Enderecos;

namespace MTJM.API.Models.Funcionarios;

public class Funcionario
{
    #region Properties
    public const decimal MINIMUM_SALARY = 990.00m;
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
            .LessThan(Funcionario.MINIMUM_SALARY)
            .WithMessage($"Salary minium is {Funcionario.MINIMUM_SALARY}");
    }
}