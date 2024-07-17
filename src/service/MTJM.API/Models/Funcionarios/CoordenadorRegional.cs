using FluentValidation;
using MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Propostas;
using MTJM.API.Models.User;

namespace MTJM.API.Models.Funcionarios;

public class CoordenadorRegional : Funcionario
{
    #region Properties
    public ICollection<Proposta> Propostas { get; set; }
    public ICollection<Cliente> Clientes { get; set; }
    public Orcamentista Orcamentista { get; set; }

    public string UserAccountId { get; set; }
    public ApplicationUser UserAccount { get; set; }

    #endregion

    #region Constructor
    private CoordenadorRegional() : base() { }

    public CoordenadorRegional(string nome,
        string sobrenome,
        DateTime dataContratacao,
        decimal salario,
        Endereco endereco) : base(nome, sobrenome, dataContratacao, salario, endereco)
    {
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new CoordenadorRegionalValidator().Validate(this);

    public void Update(RequestOrcamentistaDTO requestDTO)
    {
        Nome = requestDTO.Nome;
        Sobrenome = requestDTO.Sobrenome;
        DataContratacao = requestDTO.DataContratacao;
        Salario = requestDTO.Salario;
        Endereco = requestDTO.Endereco;

        ValidateModel();
    }

    public void SetUserAccount(string userAccountId)
        => UserAccountId = userAccountId;

    #endregion
}

#region Fluent Validation
public class CoordenadorRegionalValidator : AbstractValidator<CoordenadorRegional>
{
    public CoordenadorRegionalValidator()
    {
        Include(new FuncionarioValidator());
    }
}
#endregion