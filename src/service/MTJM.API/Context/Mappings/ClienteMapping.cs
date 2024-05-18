﻿using Microsoft.EntityFrameworkCore;
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

        builder.ToTable("Clientes");
    }
}
