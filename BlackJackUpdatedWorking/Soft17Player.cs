namespace BlackJackUpdatedWorking
{
    public class Soft17Player : Player
    {
        protected override int MaxPlayerHandValue { get; } = 17;

        public Soft17Player(IDeck deck) : base(deck)
        {
            
          
        }

        public override void PlayTurn()
        {
            while (HandValue() < MaxPlayerHandValue)
            {
                DrawCard();
            }
            
            
        }
        
        
        
       
    }
}