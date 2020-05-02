using System;
using System.Collections.Generic;
using System.Linq;
using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Mvc;


namespace ChronoClashDeckBuilder.Controllers
{
    public class DeckBuilderController : Controller
    {
        private ICardRepository repository;
        List<Card> curDeck = new List<Card>();

        public DeckBuilderController(ICardRepository repo)
        {
            repository = repo;
        }
        //Look at using cookies
        [HttpGet]
        public IActionResult Index(string cardNumber, string cardName, string cardColor, string cardAbility)
        {
            if (cardNumber != null)
                curDeck.Add(repository.GetCard(cardNumber));
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

        public RedirectToActionResult AddToDeck(string cardNumber)
        {
            curDeck.Add(repository.GetCard(cardNumber));
            return RedirectToAction("Index");
        }
    }
}