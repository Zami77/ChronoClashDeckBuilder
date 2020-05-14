using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models.ViewModels
{
    public class DecksListViewModel
    {
        public IEnumerable<Deck> Decks { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}
