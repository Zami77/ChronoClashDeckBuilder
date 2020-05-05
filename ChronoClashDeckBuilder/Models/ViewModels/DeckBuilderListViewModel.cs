using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models.ViewModels
{
    public class DeckBuilderListViewModel
    {
        public PaginatedList<Card> Cards { get; set; }
        public CurDeck NewDeck { get; set; }
    }
}
