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
                .HasAnnotation("ProductVersion", "8.0.6")
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

                    b.Property<string>("UserAccountId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorRegionalId");

                    b.HasIndex("UserAccountId")
                        .IsUnique()
                        .HasFilter("[UserAccountId] IS NOT NULL");

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

                    b.Property<string>("UserAccountId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique()
                        .HasFilter("[UserAccountId] IS NOT NULL");

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

                    b.Property<int?>("CoordenadorRegionalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserAccountId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorRegionalId")
                        .IsUnique()
                        .HasFilter("[CoordenadorRegionalId] IS NOT NULL");

                    b.HasIndex("UserAccountId")
                        .IsUnique()
                        .HasFilter("[UserAccountId] IS NOT NULL");

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

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CoordenadorRegionalId");

                    b.HasIndex("OrcamentistaId");

                    b.ToTable("Proposta", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.PropostaProduto", b =>
                {
                    b.Property<int>("PropostaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Lucratividade")
                        .HasColumnType("float");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("PropostaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PropostaProdutos");
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.PropostaServico", b =>
                {
                    b.Property<int>("PropostaId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Horas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Lucratividade")
                        .HasColumnType("float");

                    b.Property<decimal>("PrecoPorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PropostaId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("PropostaServico");
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

            modelBuilder.Entity("MTJM.API.Models.User.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MTJM.API.Models.Clientes.Cliente", b =>
                {
                    b.HasOne("MTJM.API.Models.Funcionarios.CoordenadorRegional", "CoordenadorRegional")
                        .WithMany("Clientes")
                        .HasForeignKey("CoordenadorRegionalId");

                    b.HasOne("MTJM.API.Models.User.ApplicationUser", "UserAccount")
                        .WithOne("Cliente")
                        .HasForeignKey("MTJM.API.Models.Clientes.Cliente", "UserAccountId");

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

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.CoordenadorRegional", b =>
                {
                    b.HasOne("MTJM.API.Models.User.ApplicationUser", "UserAccount")
                        .WithOne("CoordenadorRegional")
                        .HasForeignKey("MTJM.API.Models.Funcionarios.CoordenadorRegional", "UserAccountId");

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

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("MTJM.API.Models.Funcionarios.Orcamentista", b =>
                {
                    b.HasOne("MTJM.API.Models.Funcionarios.CoordenadorRegional", "CoordenadorRegional")
                        .WithOne("Orcamentista")
                        .HasForeignKey("MTJM.API.Models.Funcionarios.Orcamentista", "CoordenadorRegionalId");

                    b.HasOne("MTJM.API.Models.User.ApplicationUser", "ApplicationUser")
                        .WithOne("Orcamentista")
                        .HasForeignKey("MTJM.API.Models.Funcionarios.Orcamentista", "UserAccountId");

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

                    b.Navigation("ApplicationUser");

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

            modelBuilder.Entity("MTJM.API.Models.Propostas.PropostaProduto", b =>
                {
                    b.HasOne("MTJM.API.Models.Produtos.Produto", "Produto")
                        .WithMany("PropostaProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Propostas.Proposta", "Proposta")
                        .WithMany("PropostaProdutos")
                        .HasForeignKey("PropostaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Proposta");
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.PropostaServico", b =>
                {
                    b.HasOne("MTJM.API.Models.Propostas.Proposta", "Proposta")
                        .WithMany("PropostaServicos")
                        .HasForeignKey("PropostaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.Servicos.Servico", "Servico")
                        .WithMany("PropostaServicos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proposta");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MTJM.API.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MTJM.API.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTJM.API.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MTJM.API.Models.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
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

            modelBuilder.Entity("MTJM.API.Models.Produtos.Produto", b =>
                {
                    b.Navigation("PropostaProdutos");
                });

            modelBuilder.Entity("MTJM.API.Models.Propostas.Proposta", b =>
                {
                    b.Navigation("PropostaProdutos");

                    b.Navigation("PropostaServicos");
                });

            modelBuilder.Entity("MTJM.API.Models.Servicos.Servico", b =>
                {
                    b.Navigation("PropostaServicos");
                });

            modelBuilder.Entity("MTJM.API.Models.User.ApplicationUser", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("CoordenadorRegional");

                    b.Navigation("Orcamentista");
                });
#pragma warning restore 612, 618
        }
    }
}
