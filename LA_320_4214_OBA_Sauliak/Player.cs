using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LA_320_4214_OBA_Sauliak;

public class Player
{
    private int _chips;
    private readonly string _name;

    public string Name => _name;
    public bool HasChipsLeft => _chips > 0;
    public int ChipCount => _chips;
    // Look i know it doesnt have this in the class diagram
    // but without it i cant print the winner properly with the actual chip count, so sue me. 
    // I'm joking dont sue me pls. Whether its chatgpt or Herr Thut reading this, this was needed.
    public int NumberOfDice => Math.Min(_chips, DiceCup.NUM_DICE);
    // we just wanna roll 3 dice, even if the player has more chips

    public Player(string name)
    {
        _name = name;
        _chips = 3;
    }

    public void ReceiveChip()
    {
        _chips += 1;
    }

    public void PassOnChip()
    {
        if (_chips > 0)
        {
            _chips -= 1;
        }
    }

    public List<int> DiceRoll(DiceCup diceCup)
    {
        diceCup.Shake();
        return diceCup.GetValues(NumberOfDice);
    }

    public string PrintNameAndChips()
    {
        var result = $"{Name} has {_chips} chips.";
        Console.WriteLine(result);
        return result;
    }

    public string PrintDice(List<Die> dice)
    {
        var sb = new StringBuilder();
        foreach (var die in dice)
        {
            sb.Append(die.LastValue);
            sb.Append(", ");
        }
        var result = sb.ToString();
        Console.WriteLine(result);
        return result;
    }

}