using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;



namespace ChronoClashDeckBuilder.Models
{
    public partial class ChronoClashDbContext : DbContext
    {
        //public ChronoClashDbContext()
        //{
        //}

        public ChronoClashDbContext(DbContextOptions<ChronoClashDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Deck> Decks{ get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9VE1296;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("PK__CardData__A4E9FFE8515C0491");
            });

            modelBuilder.Entity<Deck>(entity =>
            {
                entity.HasKey(e => e.DeckId)
                    .HasName("PK__DeckData__76B5444CE62B9516");

                entity.Property(e => e.DeckId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserAcco__536C85E556D88902");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
