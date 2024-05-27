using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Repositories.Propostas;

public class PropostaRepository : Repository<Proposta>, IPropostaRepository
{
    public PropostaRepository(AppDbContext context) : base(context)
    {

    }
}
