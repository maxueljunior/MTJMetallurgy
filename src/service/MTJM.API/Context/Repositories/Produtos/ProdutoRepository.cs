using MTJM.API.Models.Produtos;

namespace MTJM.API.Context.Repositories.Produtos;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }


}
