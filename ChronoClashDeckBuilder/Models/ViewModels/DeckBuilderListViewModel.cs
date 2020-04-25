﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChronoClashDeckBuilder.Models.ViewModels
{
    public class DeckBuilderListViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
        public List<Card> NewDeck { get; set; }
    }
}