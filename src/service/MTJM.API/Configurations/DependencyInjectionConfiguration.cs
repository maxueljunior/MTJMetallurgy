using MTJM.API.Context.Repositories.Servicos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        #region Repositories
        builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
        #endregion


        return builder;
    }
}
