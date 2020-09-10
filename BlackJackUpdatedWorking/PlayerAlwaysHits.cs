namespace BlackJackUpdatedWorking
{
    public class PlayerAlwaysHits : Player
    {
        public PlayerAlwaysHits(IDeck deck) : base(deck)
        {
        }

        public override void PlayTurn()
        {
            while (HandValue() < 22)
            {
                DrawCard();
            }
        }
    }
}