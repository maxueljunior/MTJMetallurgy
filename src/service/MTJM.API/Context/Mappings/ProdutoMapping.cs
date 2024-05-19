using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Produtos;

namespace MTJM.API.Context.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Propostas)
            .WithMany(p => p.Produtos);

        builder.ToTable("Produto");
    }
}
