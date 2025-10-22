using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class Die
    {
        public const int MAX_NUMBER = 6;
        public Random _random;
        public int _lastValue { get; set; }
        public int LastValue { get { return _lastValue; } }

        public void Roll()
        {
            _random = new Random();
            _lastValue = _random.Next(1, MAX_NUMBER + 1);
        }
    }
}
