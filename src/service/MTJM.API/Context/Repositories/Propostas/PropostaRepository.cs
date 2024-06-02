using Microsoft.EntityFrameworkCore;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Repositories.Propostas;

public class PropostaRepository : Repository<Proposta>, IPropostaRepository
{
    private readonly AppDbContext _context;
    public PropostaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Proposta> GetByIdAllProdutosAndServicos(int propostaId)
    {
        return await _context.Propostas
            .Include(p => p.Servicos)
            .FirstOrDefaultAsync(p => p.Id == propostaId);
    }
}
