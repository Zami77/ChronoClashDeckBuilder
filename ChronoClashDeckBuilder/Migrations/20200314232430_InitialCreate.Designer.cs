﻿// <auto-generated />
using System;
using ChronoClashDeckBuilder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChronoClashDeckBuilder.Migrations
{
    [DbContext(typeof(ChronoClashDbContext))]
    [Migration("20200314232430_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChronoClashDeckBuilder.Models.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CardAbilities")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("CardColor")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int?>("CardCost")
                        .HasColumnType("int");

                    b.Property<string>("CardImage")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("CardSet")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CardStackAbilities")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("CardStrength")
                        .HasColumnType("int");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("CardNumber")
                        .HasName("PK__CardData__A4E9FFE8515C0491");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ChronoClashDeckBuilder.Models.Deck", b =>
                {
                    b.Property<int>("DeckId")
                        .HasColumnName("DeckID")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfExtraDeck")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfMainDeck")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSideDeck")
                        .HasColumnType("int");

                    b.HasKey("DeckId")
                        .HasName("PK__DeckData__76B5444CE62B9516");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("ChronoClashDeckBuilder.Models.UserAccount", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Username")
                        .HasName("PK__UserAcco__536C85E556D88902");

                    b.ToTable("UserAccount");
                });
#pragma warning restore 612, 618
        }
    }
}