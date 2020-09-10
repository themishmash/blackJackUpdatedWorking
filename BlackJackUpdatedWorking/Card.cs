namespace BlackJackUpdatedWorking
{
    public class Card
    {
        public readonly CardFace CardFace;
        public readonly Suit Suit;
        public readonly int ValueOfCardFace;

        private const int MaxValueOfCards = 10;

        public Card(CardFace cardFace, Suit suit)
        {
            CardFace = cardFace;
            Suit = suit;
            ValueOfCardFace = (int) cardFace + 1;
            if (ValueOfCardFace > MaxValueOfCards) ValueOfCardFace = MaxValueOfCards;
        }
    }
}