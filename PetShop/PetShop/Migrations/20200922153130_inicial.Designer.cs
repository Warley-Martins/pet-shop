﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShop;

namespace PetShop.Migrations
{
    [DbContext(typeof(PetShopContext))]
    [Migration("20200922153130_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dll_pet_shop.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PotencialDeFelicidade")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<bool>("Usado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Alimentos");
                });

            modelBuilder.Entity("dll_pet_shop.Animais.Cachorro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Felicidade")
                        .HasColumnType("int");

                    b.Property<bool>("Limpo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Cachorro");
                });

            modelBuilder.Entity("dll_pet_shop.Animais.Gato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Felicidade")
                        .HasColumnType("int");

                    b.Property<bool>("Limpo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Gatos");
                });

            modelBuilder.Entity("dll_pet_shop.Brinquedo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Durabilidade")
                        .HasColumnType("int");

                    b.Property<int>("PotencialDeFelicidade")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<bool>("Usado")
                        .HasColumnType("bit");

                    b.Property<int>("Utilizado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Brinquedos");
                });

            modelBuilder.Entity("dll_pet_shop.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int?>("CachorroId")
                        .HasColumnType("int");

                    b.Property<int?>("GatoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CachorroId");

                    b.HasIndex("GatoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("dll_pet_shop.Join.ClienteAlimento", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "AlimentoId");

                    b.HasIndex("AlimentoId");

                    b.ToTable("ClienteAlimento");
                });

            modelBuilder.Entity("dll_pet_shop.Join.ClienteBrinquedo", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("BrinquedoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "BrinquedoId");

                    b.HasIndex("BrinquedoId");

                    b.ToTable("ClienteBrinquedo");
                });

            modelBuilder.Entity("dll_pet_shop.Cliente", b =>
                {
                    b.HasOne("dll_pet_shop.Animais.Cachorro", "Cachorro")
                        .WithMany()
                        .HasForeignKey("CachorroId");

                    b.HasOne("dll_pet_shop.Animais.Gato", "Gato")
                        .WithMany()
                        .HasForeignKey("GatoId");
                });

            modelBuilder.Entity("dll_pet_shop.Join.ClienteAlimento", b =>
                {
                    b.HasOne("dll_pet_shop.Alimento", "Alimento")
                        .WithMany()
                        .HasForeignKey("AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dll_pet_shop.Cliente", "Cliente")
                        .WithMany("ProdutosAlimentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dll_pet_shop.Join.ClienteBrinquedo", b =>
                {
                    b.HasOne("dll_pet_shop.Brinquedo", "Brinquedo")
                        .WithMany()
                        .HasForeignKey("BrinquedoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dll_pet_shop.Cliente", "Cliente")
                        .WithMany("ProdutosBrinquedos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
