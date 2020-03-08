using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoClashDeckBuilder.Models
{
    public partial class Card
    {
        [Key]
        [StringLength(20)]
        public string CardNumber { get; set; }
        [StringLength(20)]
        public string CardSet { get; set; }
        [StringLength(20)]
        public string CardType { get; set; }
        [StringLength(100)]
        public string CardImage { get; set; }
        [StringLength(10)]
        public string CardColor { get; set; }
        public int? CardCost { get; set; }
        public int? CardStrength { get; set; }
        [StringLength(80)]
        public string CardName { get; set; }
        [StringLength(200)]
        public string CardAbilities { get; set; }
        [StringLength(200)]
        public string CardStackAbilities { get; set; }
    }
}
