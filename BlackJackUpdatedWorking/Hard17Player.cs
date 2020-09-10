namespace BlackJackUpdatedWorking
{
    public class Hard17Player : Player
    {
        protected override int MaxPlayerHandValue { get; } = 17;
        
        public Hard17Player(IDeck deck) : base(deck)
        {
            
          
        }

        public override void PlayTurn()
        {
            while (HandValue() <= MaxPlayerHandValue)
            {
                DrawCard();
            }
        }

    }
}