﻿using FluentValidation;
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

    public decimal? ValorTotal { get; private set; }
    public int? Prazo { get; private set; }
    public Status Status { get; private set; }
    public string CondicaoPagamento { get; private set; }
    public int ClienteId { get; private set; } // Required foreign key property
    public Cliente Cliente { get; private set; } // Required reference navigation to principal
    public int CoordenadorRegionalId { get; private set; } // Required foreign key property
    public CoordenadorRegional CoordenadorRegional { get; private set; } // Required reference navigation to principal
    public int OrcamentistaId { get; private set; } // Required foreign key property
    public Orcamentista Orcamentista { get; private set; } // Required reference navigation to principal
    public ICollection<Produto> Produtos { get; private set; } = new List<Produto>();
    public ICollection<Servico> Servicos { get; private set; } = new List<Servico>();
    #endregion

    #region Constructors
    private Proposta() { }

    public Proposta(int clienteId, int coordenadorRegionalId, int orcamentistaId)
    {
        ClienteId = clienteId;
        CoordenadorRegionalId = coordenadorRegionalId;
        OrcamentistaId = orcamentistaId;
        SetStatus(Status.EM_ELABORACAO);
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel() => ValidationResult = new PropostaValidator().Validate(this);
    private void SetStatus(Status status) => Status = status;
    public void AddProduto(Produto produto)
    {
        Produtos.Add(produto);
        var valorTotal = (decimal)(produto.Quantidade * double.Parse(produto.Preco.ToString()));
        RecalcularValorTotal(valorTotal);
    }
    private void RecalcularValorTotal(decimal valorTotal) => ValorTotal = valorTotal;
    #endregion
}

#region Fluent Validation
public class PropostaValidator : AbstractValidator<Proposta>
{
    public PropostaValidator()
    {

        RuleFor(p => p.ValorTotal)
            .GreaterThanOrEqualTo(Proposta.MINIMUM_VALOR_TOTAL)
            .WithMessage($"Minimum Valor Total is {Proposta.MINIMUM_VALOR_TOTAL}");

        RuleFor(p => p.Prazo)
            .GreaterThanOrEqualTo(Proposta.MINIMUM_PRAZO)
            .WithMessage($"Minimum Prazo is {Proposta.MINIMUM_PRAZO}");

        RuleFor(p => p.ClienteId)
            .NotEmpty()
            .WithMessage("Cliente Id is required.");

        RuleFor(p => p.CoordenadorRegionalId)
            .NotEmpty()
            .WithMessage("Coordenador Regional Id is required.");

        RuleFor(p => p.OrcamentistaId)
            .NotEmpty()
            .WithMessage("Orcamentista Id is required.");
    }
}
#endregion