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
        private int _chips { get; set; }
        private string _name { get; set; }
        public string Name { get { return _name; } }
        public bool HasChipsLeft { get { return _chips > 0; } }
        public int NumberOfDice { get { return _chips; } }

        public Player(string name)
        {
            _name = name;
            _chips = 3;
        }
        public void RecieveChips()
        {
            _chips += 1;
        }
        public void PassOnChips()
        {
            _chips -= 1;
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
            var result = string.Empty;
            foreach (var die in dice)
            {
                result += $"{die.LastValue}, ";
            }
            Console.WriteLine(result);
            return result;
        }
        
    }
}