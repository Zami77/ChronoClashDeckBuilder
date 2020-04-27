using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            //if (cardNumber != null)
            //    curDeck.Add(repository.GetCard(cardNumber));

            return View(new Models.ViewModels.DeckBuilderListViewModel
            {
                Cards = repository.Cards,
                NewDeck = curDeck
            });
        }

        [HttpPost]
        public void AddCard(String cardNum)
        {
            curDeck.Add(repository.GetCard(cardNum));
            RedirectToAction("Index");
        }
    }
}