using System.Collections.Generic;
using System.Linq;

namespace BlackJackUpdatedWorking
{
    public abstract class Player
    {
        private readonly ICollection<Card> _hand = new List<Card>(); 
        private readonly IDeck _deck;

        private int _value;
       
        protected virtual int MaxPlayerHandValue { get; }

        public GameStatus GameStatus { get; set; }

        protected Player(IDeck deck)
        {
            _deck = deck;
            GameStatus = GameStatus.Playing;
        }

        public void NewHand()
        {
            DrawCard();
            DrawCard();
        }


        protected virtual void DrawCard()
        {
            var playerCard = _deck.DrawCard();
            _hand.Add(playerCard);
        }

        public int HandValue()
        {
            _value = _hand.Sum(card => card.ValueOfCardFace);
            if (_hand.Any(card => card.CardFace == CardFace.Ace) && _value <= 11) 
            {
                return _value + 10;
            }
            
            return _value;
        }
        
        public string PrintPlayerHand()
        {
            var returnString = string.Empty;
            foreach (var card in _hand)
            {
                returnString += card.CardFace + " " + card.Suit + " ";
            }
            
            return returnString;
        }
        
        public abstract void PlayTurn();


    }
}