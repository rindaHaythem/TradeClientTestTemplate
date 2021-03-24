﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeClientTestTemplate.Data;

namespace TradeClientTestTemplate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeClientTestTemplate.Models.EquitiesSymbols", b =>
                {
                    b.Property<int>("SymbolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SymbolId");

                    b.ToTable("EquitiesSymbols");
                });

            modelBuilder.Entity("TradeClientTestTemplate.Models.Order", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClOrdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Side")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeInForce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("limitPrice")
                        .HasColumnType("real");

                    b.Property<float>("stopPrice")
                        .HasColumnType("real");

                    b.HasKey("LocalId");

                    b.ToTable("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
