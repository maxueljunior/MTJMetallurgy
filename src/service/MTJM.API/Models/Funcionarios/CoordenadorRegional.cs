using FluentValidation;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios;

public class CoordenadorRegional : Funcionario
{
    #region Properties
    public ICollection<Proposta> Propostas { get; set; }
    public ICollection<Cliente> Clientes { get; set; }
    public Orcamentista Orcamentista { get; set; }
    #endregion

    #region Constructor
    private CoordenadorRegional() : base() { }

    public CoordenadorRegional(string nome,
        string sobrenome,
        DateTime dataContratacao,
        decimal salario,
        Endereco endereco,
        Cargo cargo) : base(nome, sobrenome, dataContratacao, salario, endereco, cargo)
    {

    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new CoordenadorRegionalValidator().Validate(this);
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