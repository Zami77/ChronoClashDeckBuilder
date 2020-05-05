using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ChronoClashDeckBuilder.Controllers
{
    public class DeckBuilderController : Controller
    {
        private ICardRepository repository;
        private CurDeck curDeck;
        public DeckBuilderController(ICardRepository repo, CurDeck deckService)
        {
            repository = repo;
            curDeck = deckService;
        }
        //Look at using cookies
        [HttpGet]
        public async Task<IActionResult> Index(string cardName, string cardColor, string cardAbility, int? pageNumber)
        {
            ViewData["CardNameFilter"] = cardName;
            ViewData["CardColorFilter"] = cardColor;
            ViewData["CardAbilityFilter"] = cardAbility;

            var cards = repository.Cards;
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
            return View(new Models.ViewModels.DeckBuilderListViewModel
            {
                Cards = await PaginatedList<Card>.CreateAsync(cards.AsNoTracking(), pageNumber ?? 1, pageSize).ConfigureAwait(true),
                NewDeck = curDeck
            }) ;
        }

        public RedirectToActionResult AddToDeck(string cardNumber, string cardName, string cardColor, string cardAbility, int? pageNumber)
        {
            Card card = repository.GetCard(cardNumber);
            if (card != null)
                curDeck.AddCard(card);
            return RedirectToAction("Index",new { cardName, cardColor, cardAbility,pageNumber });
        }

        public RedirectToActionResult RemoveFromDeck(string cardNumber, string cardName, string cardColor, string cardAbility,int? pageNumber)
        {
            Card card = repository.GetCard(cardNumber);
            if (card != null)
                curDeck.RemoveCard(card);
            return RedirectToAction("Index", new { cardName, cardColor, cardAbility,pageNumber });
        }
    }
}