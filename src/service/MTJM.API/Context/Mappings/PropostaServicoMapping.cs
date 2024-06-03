using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Context.Mappings;

public class PropostaServicoMapping : IEntityTypeConfiguration<PropostaServico>
{
    public void Configure(EntityTypeBuilder<PropostaServico> builder)
    {
        builder.HasKey(ps => new { ps.PropostaId, ps.ServicoId });

        builder.HasOne(ps => ps.Proposta)
            .WithMany(p => p.PropostaServicos)
            .HasForeignKey(ps => ps.PropostaId);

        builder.HasOne(ps => ps.Servico)
            .WithMany(s => s.PropostaServicos)
            .HasForeignKey(ps => ps.ServicoId);
    }
}
