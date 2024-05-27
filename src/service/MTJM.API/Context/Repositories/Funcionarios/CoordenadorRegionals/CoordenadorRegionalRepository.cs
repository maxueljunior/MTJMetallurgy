using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Context.Repositories.Funcionarios;

public class CoordenadorRegionalRepository : Repository<CoordenadorRegional>, ICoordenadorRegionalRepository
{
    public CoordenadorRegionalRepository(AppDbContext context) : base(context)
    {
    }

}
