using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class Die
{
    private const int MAX_NUMBER = 6;
    private static readonly Random s_random = Random.Shared; // wanna use a shared rng to avoidf repeated seeds
    private int _lastValue { get; set; }
    public int LastValue { get { return _lastValue; } }

    public void Roll()
    {
        _lastValue = s_random.Next(1, MAX_NUMBER + 1);
    }
}
