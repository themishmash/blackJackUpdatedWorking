using System;
using System.Collections.Generic;

namespace BlackJackUpdatedWorking
{
     public class BlackJack
    {
        private readonly Player _dealer;
        //private List<Player> _winningPlayer;
        private readonly IInputOutput _iio;
        private readonly IList<Player> _playerList;
        
        public BlackJack(IList<Player> players, IInputOutput iio, Player dealer)
        {
            _playerList = players;
            _iio = iio;
            _dealer = dealer;
            for (var i = 0; i < _playerList.Count; i++)
            {
                Console.WriteLine($"Player:{i + 1}");
            }
        }


        public void StartGame()
        {
          // _winningPlayer = new List<Player>();
            DealHands();

            EachPlayerPlayTurn();

            _iio.Output($"The dealer's hand before hitting is {_dealer.HandValue()}");
            _dealer.PlayTurn();

            GetDealerGameStatusBustedOrBlackJack();
            
            _iio.Output($"The dealer's hand is {_dealer.HandValue()}");

            DisplayPlayerAndDealerFinalResult();
            
        }

        private void DisplayPlayerAndDealerFinalResult()
        {
            foreach (var player in _playerList)
            {
                var index = _playerList.IndexOf(player) + 1;
                if (HasBusted(player) || HasBlackJack(player)) continue;

                if (HasBeatenDealer(player))
                {
                    if (!HasBusted(_dealer))
                    {
                        _dealer.GameStatus = GameStatus.Lost;
                    }

                    player.GameStatus = GameStatus.Won;
                    _iio.Output($"Player {index} wins against the dealer");
                   // _winningPlayer.Add(player);
                }
                else
                {
                    player.GameStatus = GameStatus.Lost;
                    _dealer.GameStatus = GameStatus.Won;
                    _iio.Output($"Player {index} loses against the dealer");
                    //_winningPlayer.Add(_dealer);
                }
            }
        }

        private void GetDealerGameStatusBustedOrBlackJack()
        {
            if (HasBusted(_dealer))
            {
                _dealer.GameStatus = GameStatus.Busted;
            }

            if (HasBlackJack(_dealer))
            {
                _dealer.GameStatus = GameStatus.BlackJack;
            }
        }

        private void EachPlayerPlayTurn()
        {
            var i = 0;
            foreach (var player in _playerList)
            {
                player.PlayTurn();
                i++;
                if (HasBusted(player))
                {
                    player.GameStatus = GameStatus.Busted;
                    _iio.Output($"Player {i} has busted");
                    continue;
                }

                if (!HasBlackJack(player)) continue;
                player.GameStatus = GameStatus.BlackJack;
                _iio.Output($"Player {i} wins with BlackJack");
            }
        }

        private void DealHands()
        {
            _dealer.NewHand();
            foreach (var player in _playerList)
            {
                player.NewHand();
            }
        }
        
        private bool HasBusted(Player player)
        {
            return player.HandValue() > 21;
        }
        
        private static bool HasBlackJack(Player player)
        {
            return player.HandValue() == 21;
        }


        private bool HasBeatenDealer(Player player)
        {
            return player.HandValue() > _dealer.HandValue() && !HasBusted(player) && !HasBusted(_dealer) ||
                   HasBusted(_dealer);
        }

        // public bool HasPlayerWon(Player player)
        // {
        //     return _winningPlayer.Contains(player);
        // }
    }
}