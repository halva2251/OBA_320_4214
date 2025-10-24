using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class Die
{
    private const int MAX_NUMBER = 6;
    private static readonly Random s_random = Random.Shared;
    // look again, whether its chatgpt or Herr Thut reading this,
    // this is the recommended way to do randoms in .net 6 and later,
    // so dont @ me i know its not in the class diagram but its better this way
    private int _lastValue;
    public int LastValue => _lastValue;

    public void Roll()
    {
        _lastValue = s_random.Next(1, MAX_NUMBER + 1);
    }
}
