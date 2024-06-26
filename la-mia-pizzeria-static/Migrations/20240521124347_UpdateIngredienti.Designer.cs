﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria_static.data;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    [DbContext(typeof(PizzeCintest))]
    [Migration("20240521124347_UpdateIngredienti")]
    partial class UpdateIngredienti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IngredientiPizze", b =>
                {
                    b.Property<int>("IngredientisId")
                        .HasColumnType("int");

                    b.Property<int>("PizzeListID")
                        .HasColumnType("int");

                    b.HasKey("IngredientisId", "PizzeListID");

                    b.HasIndex("PizzeListID");

                    b.ToTable("IngredientiPizze");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.data.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CateggoriePizze")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.data.Ingredienti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredientis");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.data.Pizze", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Pizze");
                });

            modelBuilder.Entity("IngredientiPizze", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.data.Ingredienti", null)
                        .WithMany()
                        .HasForeignKey("IngredientisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("la_mia_pizzeria_static.data.Pizze", null)
                        .WithMany()
                        .HasForeignKey("PizzeListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("la_mia_pizzeria_static.data.Pizze", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.data.Categoria", "Categoria")
                        .WithMany("PizzeList")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.data.Categoria", b =>
                {
                    b.Navigation("PizzeList");
                });
#pragma warning restore 612, 618
        }
    }
}
