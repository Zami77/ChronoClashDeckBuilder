using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models
{
    public class CardModel
    {
        [Key]
        public string CardNumber { get; set; }
        public string CardSet { get; set; }
        public string CardType { get; set; }
        public string CardImage { get; set; }
        public string CardColor { get; set; }
        public int CardCost { get; set; }
        public int CardStrength { get; set; }
        public string CardName { get; set; }
        public string CardAbilities { get; set; }
        public string CardStackAbilities { get; set; }

    }
}
