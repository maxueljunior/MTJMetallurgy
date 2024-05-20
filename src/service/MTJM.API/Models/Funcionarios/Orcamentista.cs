using FluentValidation;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios;

public class Orcamentista : Funcionario
{
    #region Properties
    public ICollection<Proposta> Propostas { get; set; }
    public int CoordenadorRegionalId { get; set; } // Required foreign key property
    public CoordenadorRegional CoordenadorRegional { get; set; } // Required reference navigation to principal
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
