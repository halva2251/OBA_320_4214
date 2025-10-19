using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak
{
    class CLI
    {
        public List<Player> RetrievePlayerData()
        {
            List<Player> players = new List<Player>();
            bool addMore = true;

            Console.WriteLine("=== Left-Center-Right Game ===");
            Console.WriteLine("Players need to enter their names.\n");

            while (addMore)
            {
                Console.Write($"Enter name for player {players.Count + 1}: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    continue;
                }

                players.Add(new Player(name));
                Console.WriteLine($"Player '{name}' added.\n");

                if (players.Count >= 3)
                {
                    addMore = DecisionMorePlayers();
                }
            }

            return players;
        }

        public bool DecisionMorePlayers()
        {
            while (true)
            {
                Console.Write("Add another player? (1 = yes, 2 = no): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    return true;
                }
                else if (input == "2")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for yes or 2 for no.");
                }
            }
        }

        public void PrintStatus(List<Player> players)
        {
            Console.WriteLine("--- Current Game Status ---");
            foreach (Player player in players)
            {
                Console.WriteLine(player.PrintNameAndChips());
            }
            Console.WriteLine("---------------------------");
        }

        public void PrintWinner(List<Player> players)
        {
            Player winner = players.FirstOrDefault(p => p.HasChips);
            if (winner != null)
            {
                Console.WriteLine("\n*** GAME OVER ***");
                Console.WriteLine($"Winner: {winner.Name}");
                Console.WriteLine("*****************\n");
            }
        }
    }
}
