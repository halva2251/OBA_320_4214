using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class Die
    {
        public const int _MAX_NUMMER = 6;
        private Random _random;
        private int _lastValue;
        private static Random _sharedRandom = new Random();

        public int LastValue
        {
            get { return _lastValue; }
        }

        public Die()
        {
            _random = _sharedRandom;
            _lastValue = 0;
        }

        public void Roll()
        {
            _lastValue = _random.Next(1, _MAX_NUMMER + 1);
        }
    }
}
