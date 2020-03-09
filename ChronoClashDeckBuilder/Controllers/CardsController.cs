using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChronoClashDeckBuilder.Controllers
{
    public class CardsController : Controller
    {
        private ICardRepository repository;
        public CardsController(ICardRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}