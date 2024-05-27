using FluentValidation;
using MTJM.API.DTOs.Funcionarios.Orcamentistas;
using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios;

public class Orcamentista : Funcionario
{
    #region Properties
    public ICollection<Proposta> Propostas { get; set; }
    public int CoordenadorRegionalId { get; set; } // Required foreign key property
    public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
    #endregion

    #region Constructors
    private Orcamentista(): base()  { }

    public Orcamentista(string nome,
        string sobrenome,
        DateTime dataContratacao,
        decimal salario,
        Endereco endereco,
        int coordenadorRegionalId) : base(nome, sobrenome, dataContratacao, salario, endereco)
    {
        CoordenadorRegionalId = coordenadorRegionalId;
        ValidateModel();
    }
    #endregion

    #region Methods
    protected override void ValidateModel()
        => ValidationResult = new OrcamentistaValidator().Validate(this);

    public void Update(RequestOrcamentistaDTO requestDTO)
    {
        Nome = requestDTO.Nome;
        Sobrenome = requestDTO.Sobrenome;
        DataContratacao = requestDTO.DataContratacao;
        Salario = requestDTO.Salario;
        Endereco = requestDTO.Endereco;
        CoordenadorRegionalId = requestDTO.CoordenadorRegionalId;

        ValidateModel();
    }
    #endregion
}

#region Fluent Validation
public class OrcamentistaValidator : AbstractValidator<Orcamentista>
{
    public OrcamentistaValidator()
    {
        Include(new FuncionarioValidator());

        RuleFor(o => o.CoordenadorRegionalId)
            .NotEmpty()
            .WithMessage("Coordenador Regional Id is required.");
    }
}
#endregion
