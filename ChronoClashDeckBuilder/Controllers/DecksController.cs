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

namespace ChronoClashDeckBuilder.Controllers
{
    public class DecksController : Controller
    {
        private IDeckRepository _deckRepository;
        private ICardRepository _cardRepository;
        private IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DecksController(IDeckRepository deckRepository, ICardRepository cardRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IHostingEnvironment hostingEnvironment)
        {
            _deckRepository = deckRepository;
            _cardRepository = cardRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;

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

        public RedirectToActionResult EditDeck(int deckId)
        {
            var routeValues = new RouteValueDictionary
            {
                {"editDeckId", deckId }
            };
            return RedirectToAction("EditDeck", "DeckBuilder",routeValues);
        }

        public IActionResult DownloadDeck(int deckId)
        {
            var deck = _deckRepository.Decks.Where(d => d.DeckId == deckId).FirstOrDefault();
            var fileName = deck.DeckName + ".txt";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", fileName);
            string vPath = filePath.Replace(@"C:\Users\chunk\OneDrive\Documents\ChronoclashWebsite\CC Code\ChronoClashDatabase\ChronoClashDeckBuilder\ChronoClashDeckBuilder\wwwroot", "~").Replace(@"\", "/");

            using (var fs = new StreamWriter(filePath))
            {
                fs.WriteLine("//Main Deck");
                foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.MainDeckCards))
                {
                    fs.WriteLine(entry.Value + " (" + entry.Key + ")");
                }
                fs.WriteLine("//Extra Deck");
                foreach (KeyValuePair<string, int> entry in CurDeck.GetCardDictionary(deck.ExtraDeckCards))
                {
                    fs.WriteLine(entry.Value + " (" + entry.Key + ")");
                }
                fs.Close();
            }
            return File(vPath, "text/plain", "Download_" + fileName);
        }
    }
}