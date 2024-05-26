﻿using MTJM.API.Context.Repositories.Clientes;
using MTJM.API.Context.Repositories.Produtos;
using MTJM.API.Context.Repositories.Servicos;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        #region Repositories
        builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        #endregion


        return builder;
    }
}
