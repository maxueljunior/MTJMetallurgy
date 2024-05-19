using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Context.Mappings;

public class OrcamentistaMapping : IEntityTypeConfiguration<Orcamentista>
{
    public void Configure(EntityTypeBuilder<Orcamentista> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.CoordenadorRegional)
            .WithOne(o => o.Orcamentista)
            .HasForeignKey<Orcamentista>(o => o.CoordenadorRegionalId)
            .IsRequired();

        builder.OwnsOne(
            o => o.Endereco,
            end =>
            {
                end.Property(e => e.Bairro).HasColumnName("Bairro");
                end.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("varchar(8)");
                end.Property(e => e.Localidade).HasColumnName("Localidade");
                end.Property(e => e.Logradouro).HasColumnName("Logradouro");
            });

        builder.ToTable("Orcamentista");
    }
}
