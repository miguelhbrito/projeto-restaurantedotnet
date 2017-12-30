﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using projetoCEDROWEBAPI.Models;
using System;

namespace projetoCEDROWEBAPI.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    partial class RestauranteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("projetoCEDROWEBAPI.Models.Prato", b =>
                {
                    b.Property<int>("IdPrato")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Preco");

                    b.Property<int?>("RestauranteId");

                    b.Property<int>("RestauranteIdRef");

                    b.HasKey("IdPrato");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("projetoCEDROWEBAPI.Models.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Restaurantes");
                });

            modelBuilder.Entity("projetoCEDROWEBAPI.Models.Prato", b =>
                {
                    b.HasOne("projetoCEDROWEBAPI.Models.Restaurante", "Restaurante")
                        .WithMany("Pratos")
                        .HasForeignKey("RestauranteId");
                });
#pragma warning restore 612, 618
        }
    }
}