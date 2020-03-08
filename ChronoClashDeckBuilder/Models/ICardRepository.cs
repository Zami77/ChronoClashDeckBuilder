using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public interface ICardRepository
    {
        Card GetCard(string cardName);
        IQueryable<Card> GetAllCards { get; }
        Card Add(Card card);
    }
}
