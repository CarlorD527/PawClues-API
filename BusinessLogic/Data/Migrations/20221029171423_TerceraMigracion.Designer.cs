﻿// <auto-generated />
using System;
using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessLogic.Data.Migrations
{
    [DbContext(typeof(PawClawsDbContext))]
    [Migration("20221029171423_TerceraMigracion")]
    partial class TerceraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"), 1L, 1);

                    b.Property<int>("Años")
                        .HasMaxLength(40)
                        .HasColumnType("int");

                    b.Property<string>("ColorPelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistritoPerdida")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Meses")
                        .HasMaxLength(40)
                        .HasColumnType("int");

                    b.Property<string>("NumeroContacto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("RazaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MascotaId");

                    b.HasIndex("RazaId");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Property<int>("RazaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RazaId"), 1L, 1);

                    b.Property<string>("NombreRaza")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("imagen")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("RazaId");

                    b.ToTable("Raza");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.HasOne("Core.Entities.Raza", "Raza")
                        .WithMany()
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Raza");
                });
#pragma warning restore 612, 618
        }
    }
}