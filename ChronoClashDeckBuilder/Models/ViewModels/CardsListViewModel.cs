using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChronoClashDeckBuilder.Models;

namespace ChronoClashDeckBuilder.Models.ViewModels
{
    public class CardsListViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
        
    }
}
