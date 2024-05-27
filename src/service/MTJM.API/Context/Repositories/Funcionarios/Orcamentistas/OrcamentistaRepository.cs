using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Context.Repositories.Funcionarios.Orcamentistas;

public class OrcamentistaRepository : Repository<Orcamentista>, IOrcamentistaRepository
{
    public OrcamentistaRepository(AppDbContext context) : base(context)
    {
    }
}
