using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class Game
{
    private Player _currentPlayer;
    private List<Player> _playerList;
    private CLI _cli;
    private DiceCup _diceCup;

    public Game()
    {
        _cli = new CLI();
        _diceCup = new DiceCup();
        _playerList = new List<Player>();
    }
    public void Play()
    {
        bool addingPlayers = true;
        
        while (addingPlayers)
        {
            var newPlayers = CLI.RetrievePlayerData();
            _playerList.AddRange(newPlayers);
            addingPlayers = CLI.DecisionMorePlayers();
        }
        bool gameOn = true;
        while (gameOn)
        {
            foreach (var player in _playerList.Where(p => p.HasChipsLeft))
            {
                _currentPlayer = player;
                var diceValues = _currentPlayer.DiceRoll(_diceCup);
                ProcessDiceRolls(diceValues);
            }
            CLI.PrintStatus(_playerList);
            // Condition to end the game would go here
            gameOn = MoreThanOnePlayerHasChips(); // Placeholder to end the loop
        }
        CLI.PrintWinner(_playerList);
    }
    public void ProcessDiceRolls(List<int> values)
    {
        // 1, 2, 3 - do nothing
        //4 Left - pass chip to left
        //Current player -1 chip index-1 +1 chip

        //5 center - pass chip to the pot
        //Current player -1 chip

        //6 Right - place chip to the right
        //Current player -1 chip index+1 +1 chip
        foreach (int value in values) {
            Console.WriteLine($"{_currentPlayer.Name} rolled {value}");
            switch (value)
            {
                case 4:
                    PassChipsToTheLeft();
                    break;
                case 5:
                    PlaceChipInPot();
                    break;
                case 6:
                    PassChipsToTheRight();
                    break;
                default:
                    // Do nothing for 1, 2, 3
                    break;
            }
        }
    }
    public void SetStartPlayer()
    {
        _currentPlayer = _playerList[0];
    }
    public void PlayerToTheRight()
    {
        _currentPlayer = _playerList[(_playerList.IndexOf(_currentPlayer) + 1) % _playerList.Count];
    }
    public void PlayerToTheLeft()
    {
        _currentPlayer = _playerList[(_playerList.IndexOf(_currentPlayer) - 1) % _playerList.Count];
    }
    public bool MoreThanOnePlayerHasChips()
    {
        return _playerList.Count(p => p.HasChipsLeft) > 1;
    }
    public void PassChipsToTheLeft()
    {
        var player  = new Player("");
        if(_playerList.IndexOf(_currentPlayer) - 1 < 0)
        {
            player = _playerList[_playerList.Count - 1];
        }
        else
        {
            player = _playerList[(_playerList.IndexOf(_currentPlayer) - 1)];
        }
        player.RecieveChips();
        _currentPlayer.PassOnChips();
        Console.WriteLine($"{_currentPlayer.Name} gave {player.Name}");
    }
    public void PassChipsToTheRight()
    {
        var player = new Player("");
        if (_playerList.IndexOf(_currentPlayer) + 1 >= _playerList.Count)
        {
            player = _playerList[0];
        }
        else
        {
            player = _playerList[(_playerList.IndexOf(_currentPlayer) + 1)];
        }
        player.RecieveChips();
        _currentPlayer.PassOnChips();
        Console.WriteLine($"{_currentPlayer.Name} gave {player.Name}");
    }
    public void PlaceChipInPot()
    {
        _currentPlayer.PassOnChips();
        Console.WriteLine($"{_currentPlayer.Name} placed a chip in the pot.");
    }
}
