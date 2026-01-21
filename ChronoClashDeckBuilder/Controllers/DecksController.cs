using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Models;
using ChronoClashDeckBuilder.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace ChronoClashDeckBuilder.Controllers
{
    public class DecksController : Controller
    {
        private IDeckRepository _deckRepository;
        private ICardRepository _cardRepository;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DecksController(IDeckRepository deckRepository, ICardRepository cardRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _deckRepository = deckRepository;
            _cardRepository = cardRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;

        }

        public IActionResult MyDecks()
        {
            DecksListViewModel decksList = new DecksListViewModel();
            decksList.Cards = _cardRepository.Cards;
            decksList.Decks = _deckRepository.Decks.Where(d => d.UserId == _userManager.GetUserId(User));
            return View(decksList);
        }

        public IActionResult PublicDecks()
        {
            DecksListViewModel decksList = new DecksListViewModel();
            decksList.Cards = _cardRepository.Cards;
            decksList.Decks = _deckRepository.Decks.OrderByDescending(d => d.DeckId);
            return View(decksList);
        }
        public IActionResult Deck(int deckId)
        {
            return View(_deckRepository.Decks.Where(d => d.DeckId == deckId));
        }

        public RedirectToActionResult DeleteDeck(int deckId)
        {
            _deckRepository.DeleteDeck(deckId);
            return RedirectToAction("MyDecks");
        }

        public RedirectToActionResult EditDeck(int deckId)
        {
            var routeValues = new RouteValueDictionary
            {
                {"editDeckId", deckId }
            };
            return RedirectToAction("EditDeck", "DeckBuilder",routeValues);
        }

        public RedirectToActionResult DownloadDeck(int deckId)
        {
            var deck = _deckRepository.Decks.Where(d => d.DeckId == deckId).FirstOrDefault();
            var fileName = deck.DeckName + ".txt";
            //var filePath = Path.Combine("wwwroot","DeckText", fileName);
            //string vPath = filePath.Replace(@"C:\Users\chunk\OneDrive\Documents\ChronoclashWebsite\CC Code\ChronoClashDatabase\ChronoClashDeckBuilder\ChronoClashDeckBuilder\wwwroot", "~").Replace(@"\", "/");
            string deckStr = "";
            
      
                deckStr += ("//Main Deck\n");
                foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.MainDeckCards))
                {
                    deckStr += (entry.Value + " (" + entry.Key + ")\n");
                }
                deckStr += ("//Extra Deck\n");
                foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.ExtraDeckCards))
                {
                    deckStr += (entry.Value + " (" + entry.Key + ")\n");
                }


            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.Headers.Add("content-disposition", "attachment; filename =" + fileName);
            Response.WriteAsync(deckStr);
            return RedirectToAction("Deck", deckId);
        }

        public string UntapDeck(int deckId)
        {
            var deck = _deckRepository.Decks.Where(d => d.DeckId == deckId).FirstOrDefault();
            string deckStr = "";


            deckStr += ("//Main Deck\n");
            foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.MainDeckCards))
            {
                deckStr += (entry.Value + " (" + entry.Key + ")\n");
            }
            deckStr += ("//Extra Deck\n");
            foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.ExtraDeckCards))
            {
                deckStr += (entry.Value + " (" + entry.Key + ")\n");
            }

            return deckStr;
        }
    }
}