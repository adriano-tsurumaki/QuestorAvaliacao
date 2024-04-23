﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FaturaContext))]
    [Migration("20240423033111_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<float>("PercentualJuros")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Banco");
                });

            modelBuilder.Entity("Domain.Entity.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BancoId")
                        .HasColumnType("integer");

                    b.Property<string>("CpfCnpjBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CpfCnpjPagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeBeneficiario")
                        .HasColumnType("text");

                    b.Property<string>("NomePagador")
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boleto");
                });

            modelBuilder.Entity("Domain.Entity.Boleto", b =>
                {
                    b.HasOne("Domain.Entity.Banco", "Banco")
                        .WithMany("ListBoleto")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("Domain.Entity.Banco", b =>
                {
                    b.Navigation("ListBoleto");
                });
#pragma warning restore 612, 618
        }
    }
}
