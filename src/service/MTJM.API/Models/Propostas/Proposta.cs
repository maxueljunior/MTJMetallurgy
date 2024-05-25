using FluentValidation;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Models.Propostas;

public class Proposta : Base
{
    #region Properties

    public const decimal MINIMUM_VALOR_TOTAL = 0.00m;
    public const int MINIMUM_PRAZO = 0;

    public decimal ValorTotal { get; set; }
    public int Prazo { get; set; }
    public Status Status { get; set; }
    public string CondicaoPagamento { get; set; }
    public int ClienteId { get; set; } // Required foreign key property
    public Cliente Cliente { get; set; } // Required reference navigation to principal
    public int CoordenadorRegionalId { get; set; } // Required foreign key property
    public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
    public int OrcamentistaId { get; set; } // Required foreign key property
    public Orcamentista Orcamentista { get; set; } // Required reference navigation to principal
    public ICollection<Produto> Produtos { get; set; }
    public ICollection<Servico> Servicos { get; set; }
    #endregion
}

#region Fluent Validation
public class PropostaValidator : AbstractValidator<Proposta>
{
    public PropostaValidator()
    {
        RuleFor(p => p.ValorTotal)
            .NotEmpty()
            .WithMessage("Valor Total is required.");

        RuleFor(p => p.ValorTotal)
            .LessThan(Proposta.MINIMUM_VALOR_TOTAL)
            .WithMessage($"Minimum Valor Total is {Proposta.MINIMUM_VALOR_TOTAL}");

        RuleFor(p => p.Prazo)
            .NotEmpty()
            .WithMessage("Prazo is required.");

        RuleFor(p => p.Prazo)
            .LessThan(Proposta.MINIMUM_PRAZO)
            .WithMessage($"Minimum Prazo is {Proposta.MINIMUM_PRAZO}");

        RuleFor(p => p.Status)
            .NotEmpty()
            .WithMessage("Status is required.");

        RuleFor(p => p.ClienteId)
            .NotEmpty()
            .WithMessage("Cliente Id is required.");

        RuleFor(p => p.CoordenadorRegionalId)
            .NotEmpty()
            .WithMessage("Cliente Id is required.");

        RuleFor(p => p.OrcamentistaId)
            .NotEmpty()
            .WithMessage("Cliente Id is required.");
    }
}
#endregion