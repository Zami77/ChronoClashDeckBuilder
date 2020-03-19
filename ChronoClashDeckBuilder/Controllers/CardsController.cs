using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChronoClashDeckBuilder.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronoClashDeckBuilder.Controllers
{
    public class CardsController : Controller
    {
        private ICardRepository repository;
        public CardsController(ICardRepository repo)
        {
            repository = repo;
        }
        // GET: Cards
        public  IActionResult Index()
        {
            return View(repository.Cards);
        }

       
    }
}