using FluentValidation;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Clientes;

public class Cliente
{
    #region Properties
    public const int MAX_LENGTH_CNPJ = 14;
    public const int MAX_LENGTH_CEP = 8;
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public Endereco Endereco { get; set; }
    public bool Ativo { get; set; }
    public int CoordenadorRegionalId { get; set; } // Required foreign key property
    public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
    public ICollection<Proposta> Propostas { get; set; }
    #endregion

    #region Methods
    public void SetActive(bool ativo)
    {
        Ativo = ativo;
    }
    #endregion
}

#region Fluent Validator
public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("Nome is required.");

        RuleFor(c => c.Cnpj)
            .NotEmpty()
            .WithMessage("CNPJ is required.");

        RuleFor(c => c.Cnpj)
            .MaximumLength(Cliente.MAX_LENGTH_CNPJ)
            .WithMessage($"CNPJ Maximum length {Cliente.MAX_LENGTH_CNPJ}");

        RuleFor(c => c.Endereco.Cep)
            .MaximumLength(Cliente.MAX_LENGTH_CEP)
            .WithMessage($"CEP Maximum length {Cliente.MAX_LENGTH_CEP}");
    }
}
#endregion
