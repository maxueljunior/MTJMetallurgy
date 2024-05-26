using FluentValidation;
using FluentValidation.Results;
using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Servicos;

public class Servico : Base
{
    #region Properties
    public const decimal MINIMUM_HORAS = 0.00m;
    public const decimal MIMIMUM_PRECO_HORA = 0.00m;

    public string Descricao { get; private set; }
    public decimal Horas { get; private set; }
    public decimal PrecoPorHora { get; private set; }
    public string Unidade { get; private set; }
    public ICollection<Proposta> Propostas { get; private set; }
    #endregion

    #region Constructors
    private Servico() { }
    public Servico(string descricao, decimal horas, decimal precoPorHora, string unidade)
    {
        Descricao = descricao;
        Horas = horas;
        PrecoPorHora = precoPorHora;
        Unidade = unidade;
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new ServicoValidator().Validate(this);

    public void Update(RequestServicoDTO requestDTO)
    {
        Descricao = requestDTO.Descricao;
        Horas = requestDTO.Horas;
        PrecoPorHora = requestDTO.PrecoPorHora;
        Unidade = requestDTO.Unidade;

        ValidateModel();
    }
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
            .GreaterThanOrEqualTo(Servico.MINIMUM_HORAS)
            .WithMessage($"Minimum horas is {Servico.MINIMUM_HORAS}");

        RuleFor(s => s.PrecoPorHora)
            .NotEmpty()
            .WithMessage("Preco Por Hora is required.");

        RuleFor(s => s.PrecoPorHora)
            .GreaterThanOrEqualTo(Servico.MIMIMUM_PRECO_HORA)
            .WithMessage($"Minimum Preco Por Hora is {Servico.MIMIMUM_PRECO_HORA}");

        RuleFor(s => s.Unidade)
            .NotEmpty()
            .WithMessage("Unidade is required.");

    }
}
#endregion
