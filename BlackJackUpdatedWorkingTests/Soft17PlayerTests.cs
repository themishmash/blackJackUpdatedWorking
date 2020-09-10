using BlackJackUpdatedWorking;
using Xunit;

namespace BlackJackUpdatedWorkingTests
{
    public class Soft17PlayerTests
    {
         [Fact]
        public void StaysOn17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Seven, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
            });
            var soft17Player = new Soft17Player(testDeck);
        
            soft17Player.PlayTurn();
            
            Assert.Equal(17, soft17Player.HandValue());
        }
        
        [Fact]
        public void HitsUnder17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Six, Suit.Spades),
                new Card(CardFace.Ten, Suit.Diamonds),
            });
            var soft17Player = new Soft17Player(testDeck);
            
            soft17Player.PlayTurn();
            
            Assert.Equal(26, soft17Player.HandValue());
        }
        
        [Fact]
        public void StaysOn20()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Jack, Suit.Spades),
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Diamonds),
            });
            var soft17Player = new Soft17Player(testDeck);
      
            soft17Player.PlayTurn();

            Assert.Equal(20, soft17Player.HandValue());

        }

        [Fact]
        public void StartsWithTwoCards()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Spades),
                new Card(CardFace.Eight, Suit.Clubs), 
            });
            var soft17Player = new Soft17Player(testDeck);
            
            soft17Player.NewHand();

            Assert.Equal(10, soft17Player.HandValue());
        }
        
    }
}