﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeClientTestTemplate.Data;

namespace TradeClientTestTemplate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210405091707_decimalprices")]
    partial class decimalprices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountTrader", b =>
                {
                    b.Property<string>("listOfAccountsaccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("listOfTraderstraderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("listOfAccountsaccountId", "listOfTraderstraderId");

                    b.HasIndex("listOfTraderstraderId");

                    b.ToTable("AccountTrader");
                });

            modelBuilder.Entity("TradeClientTestTemplate.Models.Account", b =>
                {
                    b.Property<string>("accountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("accountFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("accountSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accountId");

                    b.ToTable("accounts");
                });

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
                    b.Property<int>("portfolioManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClOrdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquityFullName")
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

                    b.Property<string>("account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("filled")
                        .HasColumnType("int");

                    b.Property<int>("leaves")
                        .HasColumnType("int");

                    b.Property<decimal>("limitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ordered")
                        .HasColumnType("int");

                    b.Property<int>("placed")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("stopPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("timeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("trader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("uncommited")
                        .HasColumnType("int");

                    b.HasKey("portfolioManagerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TradeClientTestTemplate.Models.Trader", b =>
                {
                    b.Property<string>("traderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("traderFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("traderSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("traderId");

                    b.ToTable("traders");
                });

            modelBuilder.Entity("AccountTrader", b =>
                {
                    b.HasOne("TradeClientTestTemplate.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("listOfAccountsaccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeClientTestTemplate.Models.Trader", null)
                        .WithMany()
                        .HasForeignKey("listOfTraderstraderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
