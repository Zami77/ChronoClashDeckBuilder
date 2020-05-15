using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public class EFDeckRepository : IDeckRepository
    {
        private ChronoClashDbContext context;
        public EFDeckRepository(ChronoClashDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Deck> Decks => context.Decks;


        public void DeleteDeck(int deckId)
        {
            context.Decks.Remove(context.Decks.Find(deckId));
            context.SaveChanges();
        }

        public void SaveDeck(Deck deck)
        {
            var deckEntry = context.Decks.Where(d => d.DeckId == deck.DeckId).FirstOrDefault();
            if (deckEntry != null)
            {
                deckEntry.DeckName = deck.DeckName;
                deckEntry.MainDeckCards = deck.MainDeckCards;
                deckEntry.ExtraDeckCards = deck.ExtraDeckCards;
                deckEntry.NumberOfMainDeck = deck.NumberOfMainDeck;
                deckEntry.numberOfExtraDeck = deck.numberOfExtraDeck;
                deckEntry.UserId = deck.UserId;
            }
            else
                context.Decks.Add(deck);
            context.SaveChanges();
        }

        public void RenameDeck(Deck deck, string newName)
        {
            if (deck == null)
                return;
            deck.DeckName = newName;
            SaveDeck(deck);
        }
    }
}