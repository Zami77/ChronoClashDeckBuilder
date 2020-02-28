using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoClashDeckBuilder.Models
{
    public class ChronoClashDbContext : DbContext
    {
        public ChronoClashDbContext(DbContextOptions<ChronoClashDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
    }
}
