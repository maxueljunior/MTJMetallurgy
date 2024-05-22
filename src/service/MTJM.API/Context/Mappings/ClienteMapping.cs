using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Clientes;

namespace MTJM.API.Context.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Cnpj)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.OwnsOne(
            c => c.Endereco,
            end =>
            {
                end.Property(e => e.Bairro).HasColumnName("Bairro");
                end.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("varchar(8)");
                end.Property(e => e.Localidade).HasColumnName("Localidade");
                end.Property(e => e.Logradouro).HasColumnName("Logradouro");
            });

        // How to add mapping for property Endereco, but i'm trying but no mapping

        builder.HasOne(e => e.CoordenadorRegional)
            .WithMany(e => e.Clientes)
            .HasForeignKey(e => e.CoordenadorRegionalId)
            .IsRequired();

        builder.ToTable("Cliente");
    }
}
