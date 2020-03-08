using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoClashDeckBuilder.Models
{
    public partial class Deck
    {
        [Key]
        [Column("DeckID")]
        public int DeckId { get; set; }
        public int? NumberOfMainDeck { get; set; }
        public int? NumberOfSideDeck { get; set; }
        public int? NumberOfExtraDeck { get; set; }
    }
}
