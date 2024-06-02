using Microsoft.EntityFrameworkCore;
using MTJM.API.Models.Clientes;
using MTJM.API.Models.Funcionarios;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Propostas;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Context;

public class AppDbContext : DbContext
{
    #region Constructor
    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
    {
        
    }
    #endregion

    #region Properties
    public DbSet<Cliente> Clientes { get; set;}
    public DbSet<CoordenadorRegional> CoordenadoresRegionais { get; set;}
    public DbSet<Orcamentista> Orcamentistas { get; set;}
    public DbSet<Produto> Produtos { get; set;}
    public DbSet<Proposta> Propostas { get; set;}
    public DbSet<Servico> Servicos { get; set;}
    public DbSet<PropostaProduto> PropostaProdutos { get; set;}
    #endregion

    #region Override Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    #endregion
}
