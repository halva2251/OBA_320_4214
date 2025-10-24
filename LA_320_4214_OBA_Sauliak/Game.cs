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
    private readonly List<Player> _playerList;
    private readonly CLI _cli;
    private readonly DiceCup _diceCup;

    public Game()
    {
        _cli = new CLI();
        _diceCup = new DiceCup();
        _playerList = new List<Player>();
    }

    public void Play()
    {
        SetStartPlayer();

        while (MoreThanOnePlayerHasChips())
        {
            var diceValues = _currentPlayer.DiceRoll(_diceCup);
            ProcessDiceRolls(diceValues);

            _currentPlayer = PlayerToTheRight(); // next players turn (to the right)

            CLI.PrintStatus(_playerList);
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
        foreach (int value in values)
        {
            Console.WriteLine($"{_currentPlayer.Name} rolled {value}");
            switch (value)
            {
                case 4:
                    PassChipToTheLeft();
                    break;
                case 5:
                    PlaceChipInPot();
                    break;
                case 6:
                    PassChipToTheRight();
                    break;
                default:
                    // 1, 2, 3: do nothing
                    break;
            }
        }
    }

    public void SetStartPlayer()
    {
        var idx = Random.Shared.Next(0, _playerList.Count);
        _currentPlayer = _playerList[idx];
    }

    public Player PlayerToTheRight()
    {
        int idx = (_playerList.IndexOf(_currentPlayer) + 1) % _playerList.Count;
        return _playerList[idx];
    }

    public Player PlayerToTheLeft()
    {
        int idx = (_playerList.IndexOf(_currentPlayer) - 1 + _playerList.Count) % _playerList.Count;
        return _playerList[idx];
    }

    public bool MoreThanOnePlayerHasChips()
    {
        return _playerList.Count(p => p.HasChipsLeft) > 1;
    }

    public void PassChipToTheLeft()
    {
        var player = PlayerToTheLeft();
        player.RecieveChip();
        _currentPlayer.PassOnChip();
        Console.WriteLine($"{_currentPlayer.Name} gave a chip to {player.Name}");
    }

    public void PassChipToTheRight()
    {
        var player = PlayerToTheRight();
        player.RecieveChip();
        _currentPlayer.PassOnChip();
        Console.WriteLine($"{_currentPlayer.Name} gave a chip to {player.Name}");
    }

    public void PlaceChipInPot()
    {
        _currentPlayer.PassOnChip();
        Console.WriteLine($"{_currentPlayer.Name} placed a chip in the pot.");
    }
}
