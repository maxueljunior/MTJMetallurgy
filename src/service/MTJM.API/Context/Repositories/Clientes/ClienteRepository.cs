using MTJM.API.Models.Clientes;

namespace MTJM.API.Context.Repositories.Clientes;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(AppDbContext context) : base(context)
    {

    }
}
