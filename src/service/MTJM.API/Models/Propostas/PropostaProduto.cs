using FluentValidation;
using MTJM.API.DTOs.Propostas;
using MTJM.API.Models.Produtos;
using System.ComponentModel.DataAnnotations;

namespace MTJM.API.Models.Propostas;

public class PropostaProduto : Base
{
    #region Properties
    public const double MIN_QUANTIDADE = 0.00;
    public int PropostaId { get; private set; }
    public Proposta Proposta { get; private set; }
    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public string Descricao { get; private set; }
    public double Quantidade { get; private set; }
    public decimal Preco { get; private set; }
    public double Lucratividade { get; private set; }
    #endregion

    #region Constructors
    private PropostaProduto() { }

    public PropostaProduto(int propostaId, int produtoId, double quantidade, decimal preco, string descricao, double lucratividade)
    {
        PropostaId = propostaId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
        Descricao = descricao;
        Lucratividade = lucratividade;

        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel() => ValidationResult = new PropostaProdutoValidator().Validate(this);
    #endregion
}

public class PropostaProdutoValidator : AbstractValidator<PropostaProduto>
{
    public PropostaProdutoValidator()
    {
        RuleFor(pp => pp.Quantidade)
            .NotEmpty()
            .WithMessage("Quantidade is required");

        RuleFor(pp => pp.Quantidade)
            .LessThanOrEqualTo(PropostaProduto.MIN_QUANTIDADE)
            .WithMessage($"Quantidade Less Than {PropostaProduto.MIN_QUANTIDADE}");

    }   
}
