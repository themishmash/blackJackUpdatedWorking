using System.Linq;
using BlackJackUpdatedWorking;
using Xunit;

namespace BlackJackUpdatedWorkingTests
{
    public class DeckTests
    {
        [Fact]
        public void StartsWith52Cards()
        {
            var deck = new Deck();
            Assert.Equal(52, deck.CardsLeft());
            
        }

        [Fact]
        public void ContainsSpecificCards()
        {
            var deck = new Deck();

            Assert.Equal(1, deck.CardList.Count(c => c.CardFace == CardFace.Ace && c.Suit == Suit.Clubs));
        }

        [Fact]
        public void DealOneCardAndRemoveFromDeck()
        {
            var deck = new Deck();
            
            var cardDrawn = deck.DrawCard();

            Assert.Equal(51, deck.CardsLeft());
            Assert.False(deck.CardList.Contains(cardDrawn)); //Windy helped with this
        }
        
        [Fact]
        public void DealDifferentCardWithEachCardDrawnDuringSameGame()
        {
            var deck = new Deck();

            var card1 = deck.DrawCard();
            var card2 = deck.DrawCard();

            Assert.NotEqual(card1, card2);
        }
        
        [Fact]
        public void CannotDrawMoreCardsWhenThereAreNoMoreCardsLeft()
        {
            var deck = new Deck();

            while (deck.CardList.Count > 0)
            {
                deck.DrawCard();
            }

            var card = deck.DrawCard();

            Assert.Null(card);
        }


    }
}