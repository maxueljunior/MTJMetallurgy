using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Context.Mappings;

public class ServicoMapping : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.Propostas)
            .WithMany(s => s.Servicos);

        builder.ToTable("Servico");
    }
}
