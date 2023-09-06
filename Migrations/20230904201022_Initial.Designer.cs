﻿// <auto-generated />
using System;
using FGO_CE_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230904201022_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.CE", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.HasKey("Guid");

                    b.ToTable("CE");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.CE_ExtraAssets", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("ExtraAssets");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.CE_Skill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.ExtraAssets_CharaGraph", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CharaGraph");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.ExtraAssets_Faces", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Faces");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.Functions_Sval", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("EventID")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "EventId");

                    b.HasKey("ID");

                    b.ToTable("Sval");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.CEModels.Skills_Function", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("FGO_CE_Manager.Data.EventModels.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("EventID")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("ID");

                    b.ToTable("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
