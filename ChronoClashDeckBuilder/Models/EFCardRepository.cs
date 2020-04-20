using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public class EFCardRepository : ICardRepository
    {
        private ChronoClashDbContext context;
        public EFCardRepository(ChronoClashDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Card> Cards => context.Cards;
        public Card Add(Card card)
        {
            context.Add(card);
            return card;
        }

        public Card GetCard(string cardNumber)
        {
            return context.Cards.Find(cardNumber);
        }
    }
}
