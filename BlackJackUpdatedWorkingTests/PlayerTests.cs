using BlackJackUpdatedWorking;
using Xunit;

namespace BlackJackUpdatedWorkingTests
{
    public class PlayerTests
    {
        
        [Fact]
        public void AceCanBeEleven()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Jack, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
            });

            var player = new PlayerImplementation(testDeck);
            player.PlayTurn();
            player.PlayTurn();

            Assert.Equal(21, player.HandValue());
        }
        
        [Fact]
        public void AddThreeAces()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ace, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts),
            });

            var player = new PlayerImplementation(testDeck);
            player.PlayTurn();
            player.PlayTurn();
            player.PlayTurn();

            Assert.Equal(13, player.HandValue());
        }
        
        [Fact]
        public void AceChangesValue()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ace, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Hearts),
                
            });

            var player = new PlayerImplementation(testDeck);
            player.PlayTurn();
            player.PlayTurn();

            Assert.Equal(12, player.HandValue());
        }

        private class PlayerImplementation:Player
        {
            public PlayerImplementation(IDeck deck) : base(deck)
            {
            }

            public override void PlayTurn()
            {
                DrawCard();
            }
        }
    }
}