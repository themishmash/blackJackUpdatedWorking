using System.Collections.Generic;
using BlackJackUpdatedWorking;

namespace BlackJackUpdatedWorkingTests
{
    public class DeckMock: IDeck
    {
        private readonly Queue<Card> _testCards = new Queue<Card>();
        
        public DeckMock(IEnumerable<Card> testCards)
        {
            foreach (var testcard in testCards)
            {
                _testCards.Enqueue(testcard);
            }
        }

        public Card DrawCard()
        {
            CardsTakenFromDeck++;
            return _testCards.Dequeue();
        }

        public int CardsLeft()
        {
            return _testCards.Count;
        }

        private int CardsTakenFromDeck
        {
            get;
            set;
        } = 0;

    }
}