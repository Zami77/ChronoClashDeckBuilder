using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public interface ICardRepository
    {
        Card GetCard(string cardName);
        IQueryable<Card> Cards { get; }
        Card Add(Card card);
    }
}
