using FluentValidation;
using MTJM.API.DTOs.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Clientes;

public class Cliente : Base
{
    #region Properties
    public const int MAX_LENGTH_CNPJ = 14;
    public const int MAX_LENGTH_CEP = 8;

    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public Endereco Endereco { get; private set; }
    public bool Ativo { get; private set; }
    public int? CoordenadorRegionalId { get; private set; } // Required foreign key property
    public CoordenadorRegional? CoordenadorRegional { get; set; } // Required reference navigation to principal
    public ICollection<Proposta> Propostas { get; set; }
    #endregion

    #region Constructor
    private Cliente() { }

    public Cliente(string nome, string cnpj, Endereco endereco)
    {
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        SetActive(true);

        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new ClienteValidator().Validate(this);
    public void SetActive(bool ativo)
    {
        Ativo = ativo;
    }

    public void Update(RequestClienteDTO requestDTO)
    {
        Nome = requestDTO.Nome;
        Cnpj = requestDTO.Cnpj;
        Endereco = requestDTO.Endereco;

        ValidateModel();
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
