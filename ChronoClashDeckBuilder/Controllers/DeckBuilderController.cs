using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Infrastructure;
using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ChronoClashDeckBuilder.Controllers
{
    public class DeckBuilderController : Controller
    {
        private ICardRepository repository;
        private IDeckRepository deckRepository;
        private CurDeck curDeck;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public DeckBuilderController(ICardRepository repo,IDeckRepository deckRepo, CurDeck deckService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            repository = repo;
            deckRepository = deckRepo;
            curDeck = deckService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string cardName, string cardColor, string cardAbility, string deckName, int? pageNumber)
        {
            ViewData["CardNameFilter"] = cardName;
            ViewData["CardColorFilter"] = cardColor;
            ViewData["CardAbilityFilter"] = cardAbility;
            ViewData["DeckName"] = deckName;

            
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
            {
                curDeck.AddCard(card);
            }
            return RedirectToAction("Index",new { cardName, cardColor, cardAbility,pageNumber });
        }

        public RedirectToActionResult RemoveFromDeck(string cardNumber, string cardName, string cardColor, string cardAbility,int? pageNumber)
        {
            Card card = repository.GetCard(cardNumber);
            if (card != null)
                curDeck.RemoveCard(card);
            return RedirectToAction("Index", new { cardName, cardColor, cardAbility,pageNumber });
        }
        public RedirectToActionResult ResetDeck()
        {
            curDeck.Clear();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult SaveDeck(string deckName)
        {
            if(curDeck.ExtraDeckCount() < 6 || curDeck.DeckCount() < 50)
            {
                TempData["message"] = "Main deck does not have 50 or more cards or Extra deck does not have 6 or more cards";
                return RedirectToAction("Index");
            }
            ViewData["DeckName"] = deckName;
            if (_signInManager.IsSignedIn(User))
            {
                if(String.IsNullOrWhiteSpace(deckName))
                {
                    deckName = _userManager.GetUserName(HttpContext.User) + " Deck ID#" + (deckRepository.Decks.OrderByDescending(d => d.DeckId).FirstOrDefault().DeckId + 1);
                }
                Deck savedDeck = new Deck()
                {
                    DeckId = deckRepository.Decks.OrderByDescending(d => d.DeckId).FirstOrDefault().DeckId + 1,
                    UserId = _userManager.GetUserId(HttpContext.User),
                    DeckName = deckName,
                    MainDeckCards = curDeck.GetMainCards(),
                    ExtraDeckCards = curDeck.GetExtraCards(),
                    NumberOfMainDeck = curDeck.DeckCount(),
                    numberOfExtraDeck = curDeck.ExtraDeckCount()
                };
                deckRepository.SaveDeck(savedDeck);
                curDeck.Clear();
                return RedirectToAction("Deck", "Decks", new {deckId = savedDeck.DeckId });
            }
            return RedirectToAction("Deck","Decks");
        }

    }
}