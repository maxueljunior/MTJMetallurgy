using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Mappings;

public class PropostaMapping : IEntityTypeConfiguration<Proposta>
{
    public void Configure(EntityTypeBuilder<Proposta> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Ignore(p => p.ValidationResult);

        builder.Property(p => p.ValorTotal)
            .IsRequired(false);

        builder.Property(p => p.Prazo)
            .IsRequired(false);

        builder.HasOne(p => p.Orcamentista)
            .WithMany(p => p.Propostas)
            .HasForeignKey(p => p.OrcamentistaId)
            .IsRequired();

        builder.HasOne(p => p.CoordenadorRegional)
            .WithMany(p => p.Propostas)
            .HasForeignKey(p => p.CoordenadorRegionalId)
            .IsRequired();

        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Propostas)
            .HasForeignKey(p => p.ClienteId)
            .IsRequired();


        builder.ToTable("Proposta");
    }
}
