using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ChronoClashDeckBuilder.Infrastructure;

namespace ChronoClashDeckBuilder.Models
{
    public class SessionDeck : CurDeck
    {
        public static CurDeck GetCurDeck(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionDeck curDeck = session?.GetJson<SessionDeck>("CurDeck")
                ?? new SessionDeck();
            curDeck.Session = session;
            return curDeck;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddCard(Card card)
        {
            base.AddCard(card);
            Session.SetJson("CurDeck", this);
        }
        public override void AddCard(Card card, int qty)
        {
            base.AddCard(card, qty);
            Session.SetJson("CurDeck", this);
        }
        public override void RemoveCard(Card card)
        {
            base.RemoveCard(card);
            Session.SetJson("CurDeck", this);
        }
        public override void RemoveLine(Card card)
        {
            base.RemoveLine(card);
            Session.SetJson("CurDeck", this);
        }
        public override void GetDeckFromRepo(Deck editDeck, ICardRepository cardRepository)
        {
            base.GetDeckFromRepo(editDeck, cardRepository);
            Session.SetJson("CurDeck", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("CurDeck");
        }
    }
}
