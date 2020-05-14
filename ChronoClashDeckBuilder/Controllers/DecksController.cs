using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Models;
using ChronoClashDeckBuilder.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChronoClashDeckBuilder.Controllers
{
    public class DecksController : Controller
    {
        private IDeckRepository _deckRepository;
        private ICardRepository _cardRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DecksController(IDeckRepository deckRepository, ICardRepository cardRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _deckRepository = deckRepository;
            _cardRepository = cardRepository;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            DecksListViewModel decksList = new DecksListViewModel();
            decksList.Cards = _cardRepository.Cards;
            decksList.Decks = _deckRepository.Decks.Where(d => d.UserId == _userManager.GetUserId(User));
            return View(decksList);
        }
        public IActionResult Deck(int deckId)
        {
            return View(_deckRepository.Decks.Where(d => d.DeckId == deckId));
        }

        public RedirectToActionResult DeleteDeck(int deckId)
        {
            _deckRepository.DeleteDeck(deckId);
            return RedirectToAction("Index");
        }
    }
}