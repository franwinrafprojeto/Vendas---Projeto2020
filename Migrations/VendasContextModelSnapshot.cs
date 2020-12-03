﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vendas.Data;

namespace Vendas.Migrations
{
    [DbContext(typeof(VendasContext))]
    partial class VendasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Vendas.Models.CadastroEndereco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCasa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CadastroEndereco");
                });

            modelBuilder.Entity("Vendas.Models.CadastroEntregador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GetRG_Entregador")
                        .HasColumnType("int");

                    b.Property<int>("Habilitação_Entregador")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Entregador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone_Entregador")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CadastroEntregador");
                });

            modelBuilder.Entity("Vendas.Models.CadastroPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Opcao_Pagamento")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CadastroPagamento");
                });

            modelBuilder.Entity("Vendas.Models.CadastroPessoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<int>("Data_Nascimento")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RG")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CadastroPessoal");
                });

            modelBuilder.Entity("Vendas.Models.Entrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("id_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("id_Endereco")
                        .HasColumnType("int");

                    b.Property<int>("id_Entregador")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Entrega");
                });

            modelBuilder.Entity("Vendas.Models.Mercadoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome_Mercadoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade_Mercadoria")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_Mercadoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mercadoria");
                });
#pragma warning restore 612, 618
        }
    }
}
