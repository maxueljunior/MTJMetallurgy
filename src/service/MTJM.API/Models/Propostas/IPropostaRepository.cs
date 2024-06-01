namespace MTJM.API.Models.Propostas;

public interface IPropostaRepository : IRepository<Proposta>
{
    Task<Proposta> GetByIdAllProdutosAndServicos(int propostaId);
}
