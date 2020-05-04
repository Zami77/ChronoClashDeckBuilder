using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public class CurDeck
    {
        private List<CardLine> lineCollection = new List<CardLine>();
        public virtual void AddCard(Card card)
        {
            CardLine line = lineCollection
                .Where(p => p.Card.CardNumber == card.CardNumber)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CardLine
                {
                    Card = card,
                    Quantity = 1
                });
            }
            else
            {
                if(line.Quantity < 3)
                    line.Quantity++;
            }
        }
        public virtual void RemoveCard(Card card)
        {
            CardLine line = lineCollection
                .Where(p => p.Card.CardNumber == card.CardNumber)
                .FirstOrDefault();
            if (line != null)
            {
                if (line.Quantity > 0)
                    line.Quantity--;
                if(line.Quantity <= 0)
                    RemoveLine(line.Card);
            }

        }
        public virtual int DeckCount() 
        {
            int numCards = 0;
            foreach (var line in lineCollection)
                numCards += line.Quantity;
            return numCards;
        }
        public virtual void RemoveLine(Card card) => lineCollection.RemoveAll(l => l.Card.CardNumber == card.CardNumber);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CardLine> Lines => lineCollection;
        
    }
    public class CardLine
    {
        public int CardLineID { get; set; }
        public Card Card { get; set; }
        public int Quantity { get; set; }
    }
}
