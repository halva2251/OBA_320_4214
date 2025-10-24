using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class CLI
{
    public static List<Player> RetrievePlayerData()
    {
        var players = new List<Player>();
        Console.WriteLine("Enter player names. Add at least 3 players.");

        // ensure at least one valid player before asking to continue cause damn this indexing is ugly
        while (true)
        {
            string? name;
            do
            {
                Console.Write("Player name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            players.Add(new Player(name.Trim()));

            if (!DecisionMorePlayers())
                break;
        }

        if (players.Count < 3)
        {
            Console.WriteLine("At least 3 players are recommended for LCR. Add more players next run.");
        }

        return players;
    }

    public static bool DecisionMorePlayers()
    {
        Console.Write("Add more players? 1 (yes) / 2 (no): ");
        var input = Console.ReadLine()?.Trim();
        return input == "1";
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
        // prefer the remaining player with chips; otherwise fall back to max chips
        var winner = players.FirstOrDefault(p => p.HasChipsLeft)
                     ?? players.OrderByDescending(p => p.NumberOfDice).First();
        Console.WriteLine($"The winner is {winner.Name} with {winner.NumberOfDice} chips :)");
    }
}
