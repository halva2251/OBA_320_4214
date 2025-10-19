using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class Game
    {
        private Player _currentPlayer;
        private List<Player> _playerList;
        private CLI _cli;
        private DiceCup _diceCup;

        public Game()
        {
            _cli = new CLI();
            _playerList = _cli.RetrievePlayerData();
            _diceCup = new DiceCup();
        }

        public void Play()
        {
            SetStartPlayer();
            Console.WriteLine($"\nStarting player: {_currentPlayer.Name}\n");

            while (MoreThanOnePlayerHasChips())
            {
                if (_currentPlayer.HasChips)
                {
                    Console.WriteLine($"{_currentPlayer.Name}'s turn:");
                    List<int> diceValues = _currentPlayer.DiceRoll(_diceCup);
                    ProcessDiceRoll(diceValues);
                }

                _currentPlayer = PlayerToTheRight();
                _cli.PrintStatus(_playerList);
                Console.WriteLine();
            }

            Player winner = _playerList.FirstOrDefault(p => p.HasChips);
            if (winner != null)
            {
                _cli.PrintWinner(_playerList);
            }
        }

        public void ProcessDiceRoll(List<int> values)
        {
            foreach (int value in values)
            {
                switch (value)
                {
                    case 1: // L - Left
                        PassChipToTheLeft();
                        break;
                    case 2: // C - Center
                        PlaceChipInPot();
                        break;
                    case 3: // R - Right
                        PassChipToTheRight();
                        break;
                    case 4: // Dot
                    case 5: // Dot
                    case 6: // Dot
                        break;
                }
            }
        }

        public void SetStartPlayer()
        {
            Random random = new Random();
            int startIndex = random.Next(_playerList.Count);
            _currentPlayer = _playerList[startIndex];
        }

        public Player PlayerToTheRight()
        {
            int currentIndex = _playerList.IndexOf(_currentPlayer);
            int rightIndex = (currentIndex + 1) % _playerList.Count;
            return _playerList[rightIndex];
        }

        public Player PlayerToTheLeft()
        {
            int currentIndex = _playerList.IndexOf(_currentPlayer);
            int leftIndex = (currentIndex - 1 + _playerList.Count) % _playerList.Count;
            return _playerList[leftIndex];
        }

        public bool MoreThanOnePlayerHasChips()
        {
            int playersWithChips = _playerList.Count(p => p.HasChips);
            return playersWithChips > 1;
        }

        public void PassChipToTheLeft()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheLeft().ReceiveChip();
        }

        public void PassChipToTheRight()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheRight().ReceiveChip();
        }

        public void PlaceChipInPot()
        {
            _currentPlayer.PassOnChip();
        }
    }
}
