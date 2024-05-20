using FluentValidation;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Models.Funcionarios;

public class CoordenadorRegional : Funcionario
{
    #region Properties
    public ICollection<Proposta> Propostas { get; set; }
    public ICollection<Cliente> Clientes { get; set; }
    public Orcamentista Orcamentista { get; set; }
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