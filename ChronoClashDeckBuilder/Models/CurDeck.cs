using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public class CurDeck
    {
        private List<CardLine> lineCollection = new List<CardLine>();
        public int curDeckId;
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
                if (line.Card.CardType == "Extra Battler" || line.Card.CardType == "Extra Action")
                {
                    if (line.Quantity < 1)
                        line.Quantity++;
                }
                else if(line.Quantity < 3)
                    line.Quantity++;
            }
        }
        public virtual void AddCard(Card card, int qty)
        {
            lineCollection.Add(new CardLine
            {
                Card = card,
                Quantity = qty
            });
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
            {
                if(line.Card.CardType != "Extra Battler" && line.Card.CardType != "Extra Action")
                    numCards += line.Quantity;
            }
            return numCards;
        }
        public virtual int ExtraDeckCount()
        {
            int numCards = 0;
            foreach (var line in lineCollection)
            {
                if (line.Card.CardType == "Extra Battler" || line.Card.CardType == "Extra Action")
                    numCards++;
            }
            return numCards;
        }

        public virtual void GetDeckFromRepo(Deck editDeck, ICardRepository cardRepository)
        {
            Dictionary<string, int> mainDeck = GetCardDictionary(editDeck.MainDeckCards);
            Dictionary<string, int> extraDeck = GetCardDictionary(editDeck.ExtraDeckCards);
            foreach (KeyValuePair<string, int> entry in mainDeck)
                this.AddCard(cardRepository.GetCard(entry.Key), entry.Value);
            foreach (KeyValuePair<string, int> entry in extraDeck)
                this.AddCard(cardRepository.GetCard(entry.Key), entry.Value);
            curDeckId = editDeck.DeckId;
        }

        public virtual string GetMainCards()
        {
            string result = "";
            foreach (var line in lineCollection)
            {
                if(line.Card.CardType != "Extra Battler")
                    result += line.Card.CardNumber + " " + line.Quantity + " ";
            }
            return result;
        }
        public virtual string GetExtraCards()
        {
            string result = "";
            foreach (var line in lineCollection)
            {
                if (line.Card.CardType == "Extra Battler")
                    result += line.Card.CardNumber + " " + line.Quantity + " ";
            }
            return result;
        }

        public static Dictionary<string,int> GetCardDictionary(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return null;
            Dictionary<string, int> finalCards = new Dictionary<string, int>();
            string[] cards = input.Split(" ");
            for(int i = 0; i < cards.Length-1;i++)
            {
                string curCard = cards[i++];
                int curCardInt = Int32.Parse(cards[i]);
                finalCards[curCard] = curCardInt;
            }
            return finalCards;

        }

        public bool ValidColors()
        {
            bool blue = false, green = false, red = false, purple = false;
            foreach(var line in lineCollection)
            {
                switch(line.Card.CardColor)
                {
                    case "Blue":
                        blue = true;
                        break;
                    case "Green":
                        green = true;
                        break;
                    case "Red":
                        red = true;
                        break;
                    case "Purple":
                        purple = true;
                        break;
                    default:
                        break;
                }
            }
            int colorCount = 0;
            if (blue) colorCount++;
            if (green) colorCount++;
            if (red) colorCount++;
            if (purple) colorCount++;

            return colorCount <= 2;
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
