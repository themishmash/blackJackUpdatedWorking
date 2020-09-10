using System;
using System.Collections.Generic;

namespace BlackJackUpdatedWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var console = new ConsoleInputOutput();
            var players = new List<Player>()
            {
                new Human(deck, console){GameStatus = GameStatus.Playing},
                new Human(deck, console){GameStatus = GameStatus.Playing},
                new Human(deck, console){GameStatus = GameStatus.Playing},
            
            };
            var dealer = new Soft17Player(deck){GameStatus = GameStatus.Playing};
            var blackjack = new BlackJack(players, console, dealer);
            
            blackjack.StartGame();
        }
    }
}