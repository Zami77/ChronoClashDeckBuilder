using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChronoClashDeckBuilder.Models;

namespace ChronoClashDeckBuilder
{
    public class IndexModel : PageModel
    {
        private readonly ChronoClashDeckBuilder.Models.ChronoClashDbContext _context;

        public IndexModel(ChronoClashDeckBuilder.Models.ChronoClashDbContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; }

        public async Task OnGetAsync()
        {
            Card = await _context.Cards.ToListAsync();
        }
    }
}
