using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.Context.Mappings;

public class CoordenadorRegionaMapping : IEntityTypeConfiguration<CoordenadorRegional>
{
    public void Configure(EntityTypeBuilder<CoordenadorRegional> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Ignore(c => c.ValidationResult);

        builder.OwnsOne(
            c => c.Endereco,
            end =>
            {
                end.Property(e => e.Bairro).HasColumnName("Bairro");
                end.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("varchar(8)");
                end.Property(e => e.Localidade).HasColumnName("Localidade");
                end.Property(e => e.Logradouro).HasColumnName("Logradouro");
            });

        builder.Ignore(c => c.TempoDeCasa);

        builder.ToTable("CoordenadorRegional");
    }
}
