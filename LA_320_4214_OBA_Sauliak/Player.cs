using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LA_320_4214_OBA_Sauliak
{
    class Player
    {
        private int _chips;
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public bool HasChips
        {
            get { return _chips > 0; }
        }

        public int NumberOfDice
        {
            get { return Math.Min(_chips, 3); }
        }

        public Player(string name)
        {
            _name = name;
            _chips = 3;
        }

        public void ReceiveChip()
        {
            _chips++;
        }

        public void PassOnChip()
        {
            if (_chips > 0)
            {
                _chips--;
            }
        }

        public List<int> DiceRoll(DiceCup diceCup)
        {
            int numberOfDice = NumberOfDice;
            diceCup.Shake();
            List<int> values = diceCup.GetValues(numberOfDice);

            Console.Write($"  Rolled {numberOfDice} dice: ");
            string diceDisplay = "";
            foreach (int value in values)
            {
                string symbol = value switch
                {
                    1 => "L",
                    2 => "C",
                    3 => "R",
                    _ => "•"
                };
                diceDisplay += symbol + " ";
            }
            Console.WriteLine(diceDisplay.Trim());

            return values;
        }

        public string PrintNameAndChips()
        {
            return $"{_name}: {_chips} chips";
        }

        public string PrintDice(List<Die> dice)
        {
            string result = "";
            foreach (Die die in dice)
            {
                int value = die.LastValue;
                string symbol = value switch
                {
                    1 => "L",
                    2 => "C",
                    3 => "R",
                    _ => "•"
                };
                result += symbol + " ";
            }
            return result.Trim();
        }
    }
}