﻿// <auto-generated />
using System;
using MTJM.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MTJM.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MTJM.API.Models.Clientes.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<int?>("CoordenadorRegionalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorRegionalId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.CoordenadorRegional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CoordenadorRegional", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.Orcamentista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CoordenadorRegionalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorRegionalId")
                        .IsUnique();

                    b.ToTable("Orcamentista", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Produtos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<int>("Unidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.Proposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CondicaoPagamento")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CoordenadorRegionalId")
                        .HasColumnType("int");

                    b.Property<int>("OrcamentistaId")
                        .HasColumnType("int");

                    b.Property<int?>("Prazo")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CoordenadorRegionalId");

                    b.HasIndex("OrcamentistaId");

                    b.ToTable("Proposta", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Servicos.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Horas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecoPorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unidade")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Servico", (string)null);
                });

            modelBuilder.Entity("ProdutoProposta", b =>
                {
                    b.Property<int>("ProdutosId")
                        .HasColumnType("int");

                    b.Property<int>("PropostasId")
                        .HasColumnType("int");

                    b.HasKey("ProdutosId", "PropostasId");

                    b.HasIndex("PropostasId");

                    b.ToTable("ProdutoProposta");
                });

            modelBuilder.Entity("PropostaServico", b =>
                {
                    b.Property<int>("PropostasId")
                        .HasColumnType("int");

                    b.Property<int>("ServicosId")
                        .HasColumnType("int");

                    b.HasKey("PropostasId", "ServicosId");

                    b.HasIndex("ServicosId");

                    b.ToTable("PropostaServico");
                });

            modelBuilder.Entity("MTJM.API.Models.Clientes.Cliente", b =>
                {
                    b.HasOne("MTJM.API.Models.Funcionarios.CoordenadorRegional", "CoordenadorRegional")
                        .WithMany("Clientes")
                        .HasForeignKey("CoordenadorRegionalId");

                    b.OwnsOne("MTJM.API.Models.Enderecos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Localidade")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Localidade");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Logradouro");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("CoordenadorRegional");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.CoordenadorRegional", b =>
                {
                    b.OwnsOne("MTJM.API.Models.Enderecos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("CoordenadorRegionalId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Localidade")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Localidade");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Logradouro");

                            b1.HasKey("CoordenadorRegionalId");

                            b1.ToTable("CoordenadorRegional");

                            b1.WithOwner()
                                .HasForeignKey("CoordenadorRegionalId");
                        });

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.Orcamentista", b =>
                {
                    b.HasOne("MTJM.API.Models.Funcionarios.CoordenadorRegional", "CoordenadorRegional")
                        .WithOne("Orcamentista")
                        .HasForeignKey("MTJM.API.Models.Funcionarios.Orcamentista", "CoordenadorRegionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MTJM.API.Models.Enderecos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("OrcamentistaId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Localidade")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Localidade");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Logradouro");

                            b1.HasKey("OrcamentistaId");

                            b1.ToTable("Orcamentista");

                            b1.WithOwner()
                                .HasForeignKey("OrcamentistaId");
                        });

                    b.Navigation("CoordenadorRegional");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.Proposta", b =>
                {
                    b.HasOne("MTJM.API.Models.Clientes.Cliente", "Cliente")
                        .WithMany("Propostas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Funcionarios.CoordenadorRegional", "CoordenadorRegional")
                        .WithMany("Propostas")
                        .HasForeignKey("CoordenadorRegionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Funcionarios.Orcamentista", "Orcamentista")
                        .WithMany("Propostas")
                        .HasForeignKey("OrcamentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("CoordenadorRegional");

                    b.Navigation("Orcamentista");
                });

            modelBuilder.Entity("ProdutoProposta", b =>
                {
                    b.HasOne("MTJM.API.Models.Produtos.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Propostas.Proposta", null)
                        .WithMany()
                        .HasForeignKey("PropostasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PropostaServico", b =>
                {
                    b.HasOne("MTJM.API.Models.Propostas.Proposta", null)
                        .WithMany()
                        .HasForeignKey("PropostasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Servicos.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MTJM.API.Models.Clientes.Cliente", b =>
                {
                    b.Navigation("Propostas");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.CoordenadorRegional", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Orcamentista");

                    b.Navigation("Propostas");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.Orcamentista", b =>
                {
                    b.Navigation("Propostas");
                });
#pragma warning restore 612, 618
        }
    }
}
