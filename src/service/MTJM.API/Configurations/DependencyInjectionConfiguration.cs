using MTJM.API.Context.Repositories.Clientes;
using MTJM.API.Context.Repositories.Funcionarios;
using MTJM.API.Context.Repositories.Funcionarios.Orcamentistas;
using MTJM.API.Context.Repositories.Produtos;
using MTJM.API.Context.Repositories.Propostas;
using MTJM.API.Context.Repositories.Servicos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Propostas;
using MTJM.API.Models.Servicos;
using MTJM.API.Services.Propostas;

namespace MTJM.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        #region Repositories
        builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<ICoordenadorRegionalRepository, CoordenadorRegionalRepository>();
        builder.Services.AddScoped<IOrcamentistaRepository, OrcamentistaRepository>();
        builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
        #endregion

        #region Services
        builder.Services.AddScoped<IPropostaServices, PropostaServices>();
        #endregion

        return builder;
    }
}
