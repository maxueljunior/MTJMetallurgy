using FluentValidation;
using MTJM.API.DTOs.Produtos;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Produtos;

public class Produto : Base
{
    #region Properties
    public const double MINIMUM_QUANTIDADE = 0.00d;
    public const decimal MINIMUM_PRECO = 0.00m;

    public string Descricao { get; set; }
    public double Quantidade { get; set; }
    public Unidade Unidade { get; set; }
    public decimal Preco { get; set; }
    public ICollection<Proposta> Propostas { get; set; }
    #endregion

    #region Constructors
    public Produto(string descricao, double quantidade, Unidade unidade, decimal preco)
    {
        Descricao = descricao;
        Quantidade = quantidade;
        Unidade = unidade;
        Preco = preco;
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new ProdutoValidator().Validate(this);

    public void Update(RequestProdutoDTO requestDTO)
    {
        Descricao = requestDTO.Descricao;
        Quantidade = requestDTO.Quantidade;
        Preco = requestDTO.Preco;
        Unidade = requestDTO.Unidade;
        ValidateModel();
    }
    #endregion
}

#region Fluent Validation
public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .WithMessage("Descrição is required.");

        RuleFor(p => p.Quantidade)
            .GreaterThanOrEqualTo(Produto.MINIMUM_QUANTIDADE)
            .WithMessage($"Minimum quantidade is {Produto.MINIMUM_QUANTIDADE}");

        RuleFor(p => p.Preco)
            .GreaterThan(Produto.MINIMUM_PRECO)
            .WithMessage($"Minimum preco is {Produto.MINIMUM_PRECO}");

        RuleFor(p => p.Unidade)
            .NotEmpty()
            .WithMessage("Unidade is required.");
    }
}
#endregion
