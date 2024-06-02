using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Mappings;

public class PropostaProdutoMapping : IEntityTypeConfiguration<PropostaProduto>
{
    public void Configure(EntityTypeBuilder<PropostaProduto> builder)
    {
        builder.HasKey(pp => new { pp.PropostaId, pp.ProdutoId });

        builder.HasOne(pp => pp.Proposta)
            .WithMany(p => p.PropostaProdutos)
            .HasForeignKey(pp => pp.PropostaId);

        builder.HasOne(pp => pp.Produto)
            .WithMany(p => p.PropostaProdutos)
            .HasForeignKey(pp => pp.ProdutoId);

    }
}
