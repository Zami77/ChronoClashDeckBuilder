using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public interface IDeckRepository
    {
        IQueryable<Deck> Decks { get; }
        void SaveDeck(Deck deck);
        void DeleteDeck(int deckId);
    }
}
