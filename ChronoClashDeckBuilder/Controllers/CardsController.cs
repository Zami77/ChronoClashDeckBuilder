using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChronoClashDeckBuilder.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronoClashDeckBuilder.Controllers
{
    public class CardsController : Controller
    {
        private ICardRepository repository;
        public CardsController(ICardRepository repo)
        {
            repository = repo;
        }
        // GET: Cards
        [HttpGet]
        public  async Task<IActionResult> Index(string currentFilter, string cardName, string cardColor,string cardAbility, int? pageNumber)
        {
            ViewData["CardNameFilter"] = cardName;
            ViewData["CardColorFilter"] = cardColor;
            ViewData["CardAbilityFilter"] = cardAbility;

            var cards = repository.Cards;

            //if (isBlue)
            //    cards = cards.Where(c => c.CardColor.Contains("Blue"));
            //if (isGreen)
            //    cards = cards.Where(c => c.CardColor.Contains("Green"));
            //if (isPurple)
            //    cards = cards.Where(c => c.CardColor.Contains("Purple"));
            //if (isRed)
            //    cards = cards.Where(c => c.CardColor.Contains("Red"));

            if (!String.IsNullOrEmpty(cardName))
            {
                cards = cards.Where(c => c.CardName.Contains(cardName));
                
            }
            if (!String.IsNullOrEmpty(cardColor))
            {
                cards = cards.Where(c => c.CardColor.Contains(cardColor));
                
            }
            if (!String.IsNullOrEmpty(cardAbility))
            {
                cards = cards.Where(c => c.CardAbilities.Contains(cardAbility));

            }
            int pageSize = 12;
            return View(await PaginatedList<Card>.CreateAsync(cards.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
       

    }
}