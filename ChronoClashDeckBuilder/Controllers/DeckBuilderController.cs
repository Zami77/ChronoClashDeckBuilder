using System;
using System.Collections.Generic;
using System.Linq;
using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(string cardName, string cardColor, string cardAbility)
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
            return View(new Models.ViewModels.DeckBuilderListViewModel
            {
                Cards = cards.OrderBy(c => c.CardNumber),
                NewDeck = curDeck
            }) ;
        }

        public RedirectToActionResult AddToDeck(string cardNumber, string cardName, string cardColor, string cardAbility)
        {
            Card card = repository.GetCard(cardNumber);
            if (card != null)
                curDeck.AddCard(card);
            return RedirectToAction("Index",new { cardName, cardColor, cardAbility });
        }

        public RedirectToActionResult RemoveFromDeck(string cardNumber, string cardName, string cardColor, string cardAbility)
        {
            Card card = repository.GetCard(cardNumber);
            if (card != null)
                curDeck.RemoveCard(card);
            return RedirectToAction("Index", new { cardName, cardColor, cardAbility });
        }
    }
}