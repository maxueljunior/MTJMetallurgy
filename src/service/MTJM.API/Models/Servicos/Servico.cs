using FluentValidation;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Servicos;

public class Servico
{
    #region Properties
    public const decimal MINIMUM_HORAS = 0.00m;
    public const decimal MIMIMUM_PRECO_HORA = 0.00m;

    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Horas { get; set; }
    public decimal PrecoPorHora { get; set; }
    public string Unidade { get; set; }
    public ICollection<Proposta> Propostas { get; set; }
    #endregion
}

#region Fluent Validation
public class ServicoValidator : AbstractValidator<Servico>
{
    public ServicoValidator()
    {
        RuleFor(s => s.Descricao)
            .NotEmpty()
            .WithMessage("Descricao is required.");

        RuleFor(s => s.Horas)
            .NotEmpty()
            .WithMessage("Horas is required.");

        RuleFor(s => s.Horas)
            .LessThan(Servico.MINIMUM_HORAS)
            .WithMessage($"Minimum horas is {Servico.MINIMUM_HORAS}");

        RuleFor(s => s.PrecoPorHora)
            .NotEmpty()
            .WithMessage("Preco Por Hora is required.");

        RuleFor(s => s.Horas)
            .LessThan(Servico.MINIMUM_HORAS)
            .WithMessage($"Minimum horas is {Servico.MINIMUM_HORAS}");

        RuleFor(s => s.Unidade)
            .NotEmpty()
            .WithMessage("Unidade is required.");

    }
}
#endregion
