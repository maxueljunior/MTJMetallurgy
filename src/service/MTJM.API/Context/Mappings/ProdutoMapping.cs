using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Produtos;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Ignore(p => p.ValidationResult);

        builder.ToTable("Produto");
    }
}
