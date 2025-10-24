using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class DiceCup
{
    public const int NUM_DICE = 3;
    private readonly List<Die> _dice;

    public DiceCup()
    {
        _dice = new List<Die>(NUM_DICE);
        for (int i = 0; i < NUM_DICE; i++)
        {
            _dice.Add(new Die());
        }
    }
    public void Shake()
    {
        foreach (var die in _dice)
        {
            die.Roll();
        }
    }
    public List<int> GetValues(int number)
    {
        var values = new List<int>(Math.Min(number, _dice.Count));
        for (int i = 0; i < number && i < _dice.Count; i++)
        {
            values.Add(_dice[i].LastValue);
        }
        return values;
    }
}

