﻿// <auto-generated />
using System;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desktop_GerenciadorDeEstoque_WPF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250307050717_AjustarTipoTransacaoFinanceira")]
    partial class AjustarTipoTransacaoFinanceira
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorDeCusto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.TransacaoFinanceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Tipo")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("TransacoesFinanceiras");
                });

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PrecoTotalVenda")
                        .HasColumnType("numeric");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Venda", b =>
                {
                    b.HasOne("Desktop_GerenciadorDeEstoque_WPF.Core.Model.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
