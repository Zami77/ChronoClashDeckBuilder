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
        public DeckBuilderController(ICardRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(List<Card> curDeck, string cardNumber)
        {
            if (curDeck == null)
                curDeck = new List<Card>();
            if (cardNumber != null)
                curDeck.Add(repository.GetCard(cardNumber));

            return View(new Models.ViewModels.DeckBuilderListViewModel
            {
                Cards = repository.Cards,
                NewDeck = curDeck
            });
        }
        [HttpPost]
        public void AddCard(String cardNum)
        {
            //curModel.NewDeck.Add(repository.GetCard(cardNum));
        }
    }
}