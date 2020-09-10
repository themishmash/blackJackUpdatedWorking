using BlackJackUpdatedWorking;
using Xunit;

namespace BlackJackUpdatedWorkingTests
{
    public class Hard17PlayerTests
    {
        [Fact]
        public void HitsOn17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Seven, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
            });
            var hard17Player = new Hard17Player(testDeck);
        
            hard17Player.PlayTurn();
            
            Assert.Equal(27, hard17Player.HandValue());
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
            var hard17Player = new Hard17Player(testDeck);
            
            hard17Player.PlayTurn();
            
            Assert.Equal(26, hard17Player.HandValue());
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
            var hard17Player = new Hard17Player(testDeck);
      
            hard17Player.PlayTurn();

            Assert.Equal(20, hard17Player.HandValue());

        }

        [Fact]
        public void StartsWithTwoCards()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Spades)
            });
            var hard17Player = new Hard17Player(testDeck);
            hard17Player.NewHand();

            Assert.Equal(10, hard17Player.HandValue());
        }
    }
}