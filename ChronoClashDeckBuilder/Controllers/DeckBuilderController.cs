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
        public IActionResult Index()
        {
            return View(new Models.ViewModels.DeckBuilderListViewModel
            {
                Cards = repository.Cards,
                NewDeck = new List<Card>()
            }) ;
        }
    }
}