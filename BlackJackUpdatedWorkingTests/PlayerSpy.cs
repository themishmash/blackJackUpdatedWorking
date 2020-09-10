using BlackJackUpdatedWorking;

namespace BlackJackUpdatedWorkingTests
{
    public class PlayerSpy: Player
    {
        public int NumberOfTimesTurnPlayed { get; private set; }
        private int _hitTimes;

        public PlayerSpy(IDeck deck, int hitTimes) : base(deck)
        {
            _hitTimes = hitTimes;
        }
        
        

        public override void PlayTurn()
        {
            NumberOfTimesTurnPlayed++;
            if (_hitTimes == 0)
                return;
            _hitTimes--;
            DrawCard();
        }

        public static PlayerSpy CreateBlackJackPlayer()
        {
            return new PlayerSpy(new DeckMock(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Ace, Suit.Hearts),
            }), 0);
        }

        public static PlayerSpy CreateLosingPlayer()
        {
            return new PlayerSpy(new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Spades),
                new Card(CardFace.Seven, Suit.Diamonds),
            }), 0);
        }

        public static PlayerSpy CreatePlayerHandValue18()
        {
            return new PlayerSpy(new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Spades),
                new Card(CardFace.Eight, Suit.Diamonds),
            }), 0);
        }

        public static PlayerSpy CreateBustedPlayer()
        {
            return new PlayerSpy(new DeckMock(new[]
            {
                new Card(CardFace.Jack, Suit.Spades),
                new Card(CardFace.Three, Suit.Diamonds),
                new Card(CardFace.Nine, Suit.Clubs),
            }), 1);
        }

    }
}

public class DealerSpy : Soft17Player
{
    private readonly IDeck _spyDeck;
    public int CardsLeftInDeckBeforeTurn; 

    public DealerSpy(IDeck deck) : base(deck)
    {
        _spyDeck = deck;
    }

    public override void PlayTurn()
    {
        CardsLeftInDeckBeforeTurn = _spyDeck.CardsLeft();
        base.PlayTurn();
    }
}
