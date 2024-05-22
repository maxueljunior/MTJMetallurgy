using MTJM.API.Models.Servicos;

namespace MTJM.API.Context.Repositories.Servicos;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(AppDbContext context) : base(context)
    {

    }
}
