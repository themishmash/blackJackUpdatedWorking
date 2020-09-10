namespace BlackJackUpdatedWorking
{
    public class Human : Player
    
    {
        // protected override int MaxPlayerHandValue { get; } = 18;

        // public bool HitCard { get; set; }
        private const int WinningScore = 21;
        private readonly IInputOutput _iio;
        private const string HitInput = "1";
        private const string StayInput = "0";

        public Human(IDeck deck, IInputOutput iio) : base(deck)
        {
            _iio = iio; 
        }
       
        public override void PlayTurn()
        {
            while (true)
            {
                _iio.Output($"You are currently at {HandValue()}");
                if (HandValue() < WinningScore && _iio.AskQuestion($"Hit or stay? (Hit = {HitInput}, Stay = {StayInput})") 
                    == HitInput)
                {
                    
                    DrawCard();
                }
                else
                {
                    return;
                }
            }
        }
        

    }
}