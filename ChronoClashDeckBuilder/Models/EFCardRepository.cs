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
        public IQueryable<Card> GetAllCards => context.Cards;
        public Card Add(Card card)
        {
            throw new NotImplementedException();
        }

        public Card GetCard(string cardName)
        {
            throw new NotImplementedException();
        }
    }
}
