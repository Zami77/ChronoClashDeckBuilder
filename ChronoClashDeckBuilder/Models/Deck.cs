using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoClashDeckBuilder.Models
{
    public partial class Deck
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DeckId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeckName { get; set; }
        public string MainDeckCards { get; set; }
        public string ExtraDeckCards { get; set; }
        public int? NumberOfMainDeck { get; set; }
        public int? numberOfExtraDeck { get; set; }

    }
}
