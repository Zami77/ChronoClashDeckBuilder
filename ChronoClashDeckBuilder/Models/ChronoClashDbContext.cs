using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace ChronoClashDeckBuilder.Models
{
    public partial class ChronoClashDbContext : IdentityDbContext
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
                optionsBuilder.UseSqlServer("Data Source=chronoclash.database.windows.net;Initial Catalog=ChronoClashDatabase;User ID=AdminChronoClash;Password=****;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
