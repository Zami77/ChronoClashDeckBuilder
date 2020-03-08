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
    public class DetailsModel : PageModel
    {
        private readonly ChronoClashDeckBuilder.Models.ChronoClashDbContext _context;

        public DetailsModel(ChronoClashDeckBuilder.Models.ChronoClashDbContext context)
        {
            _context = context;
        }

        public Card Card { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Card = await _context.Cards.FirstOrDefaultAsync(m => m.CardNumber == id);

            if (Card == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
