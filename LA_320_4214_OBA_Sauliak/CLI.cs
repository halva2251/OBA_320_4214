using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class CLI
    {
        public static List<Player> RetrievePlayerData()
        {
            List<Player> players = new List<Player>();
            Console.WriteLine("Enter player names separated by commas:");
            var input = Console.ReadLine();
            if (input != null)
            {
                var names = input.Split(',');
                foreach (var name in names)
                {
                    players.Add(new Player(name.Trim()));
                }
            }
            return players;
        }
        public static bool DecisionMorePlayers()
        {
            Console.WriteLine("Do you want to add more players? (y/n):");
            var input = Console.ReadLine();
            if (input != null && (input.ToLower() == "y" || input.ToLower() == "yes"))
            {
                return true;
            }
            return false;
        }
        public static void PrintStatus(List<Player> players)
        {
            Console.WriteLine("Current Player Status:");
            foreach (var player in players)
            {
                player.PrintNameAndChips();
            }
        }
        public static void PrintWinner(List<Player> players)
        {
            var winner = players.OrderByDescending(p => p.NumberOfDice).First();
            Console.WriteLine($"The winner is {winner.Name} with {winner.NumberOfDice} chips!");
        }
    }
}
