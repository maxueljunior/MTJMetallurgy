using FluentValidation;
using MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;
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
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new CoordenadorRegionalValidator().Validate(this);

    public void Update(RequestCoordenadorRegionalDTO requestDTO)
    {
        Nome = requestDTO.Nome;
        Sobrenome = requestDTO.Sobrenome;
        DataContratacao = requestDTO.DataContratacao;
        Salario = requestDTO.Salario;
        Endereco = requestDTO.Endereco;
        Cargo = requestDTO.Cargo;

        ValidateModel();
    }
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