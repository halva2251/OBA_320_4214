using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class DiceCup
    {
        public const int NUM_DICE = 3;
        private List<Die> _dice;

        public DiceCup()
        {
            _dice = new List<Die>();
            for (int i = 0; i < NUM_DICE; i++)
            {
                _dice.Add(new Die());
            }
        }

        public void Shake()
        {
            foreach (Die die in _dice)
            {
                die.Roll();
            }
        }

        public List<int> GetValues(int number)
        {
            List<int> values = new List<int>();
            for (int i = 0; i < number && i < _dice.Count; i++)
            {
                values.Add(_dice[i].LastValue);
            }
            return values;
        }
    }
}
