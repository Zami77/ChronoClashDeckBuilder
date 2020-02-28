using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public interface ICardRepository
    {
        IQueryable<Card> Cards { get; }
    }
}
