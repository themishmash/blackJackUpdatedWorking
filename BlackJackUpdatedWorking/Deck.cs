using System;
using System.Collections.Generic;

namespace BlackJackUpdatedWorking
{
    public class Deck : IDeck
    {
        private static readonly Random Rng = new Random(); //This is to do with shuffle cards
        public readonly List<Card> CardList = new List<Card>();


        public Deck()
        {
            CreateDeck();
            ShuffleCards();
        }

        private void CreateDeck()
        {
            AddCardsForSuit();
        }

        private void ShuffleCards()
        {
            var n = CardList.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = CardList[k];
                CardList[k] = CardList[n];
                CardList[n] = value;
            }
        }
        
        public int CardsLeft()
        {
            return CardList.Count;
        }

        public Card DrawCard()
        {
            if (CardList.Count > 0)
            {
                var card = CardList[0];
                CardList.Remove(card);
                return card;
            }
            return null;
        }

        private void AddCardsForSuit()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace)))
                CardList.Add(new Card(cardFace, suit));
        }
    }
}