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
        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // to track unique names hashing should be faster

        var sep = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(sep);
        Console.WriteLine("Player Setup");
        Console.WriteLine(sep);
        Console.WriteLine("Enter player names. Add at least 3 players.");
        Console.WriteLine(sep);

        // ensure at least one valid unique player before asking to continue
        while (true)
        {
            string? name;

            // keep asking until a unique and non-empty name is provided
            while (true)
            {
                Console.Write("Player name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                    Console.WriteLine(sep);
                    continue;
                }

                name = name.Trim();

                if (existingNames.Contains(name))
                {
                    Console.WriteLine("A player with that name already exists. Please enter a different name.");
                    Console.WriteLine(sep);
                    continue;
                }

                break;
            }

            players.Add(new Player(name));
            existingNames.Add(name);

            if (!DecisionMorePlayers())
                break;

            Console.WriteLine(sep);
        }

        if (players.Count < 3)
        {
            Console.WriteLine(sep);
            Console.WriteLine("At least 3 players are recommended for LCR. Add more players next run.");
            Console.WriteLine(sep);
        }

        return players;
    }

    public static bool DecisionMorePlayers()
    {
        Console.Write("Add more players? 1 (yes) / 2 (no): ");
        var input = Console.ReadLine()?.Trim();
        return input == "1" || string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase); // non case sensitive yes also means yes in case the user is a bit slow
    }

    public static void PrintStatus(List<Player> players)
    {
        var sep = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(sep);
        Console.WriteLine("Current Player Status");
        Console.WriteLine(sep);

        foreach (var player in players)
        {
            player.PrintNameAndChips();
        }

        Console.WriteLine(sep);
        Console.WriteLine();
    }

    public static void PrintWinner(List<Player> players)
    {
        // prefer the remaining player with chips; otherwise fall back to max chips
        var winner = players.FirstOrDefault(p => p.HasChipsLeft)
                     ?? players.OrderByDescending(p => p.NumberOfDice).First();

        var sep = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(sep);
        Console.WriteLine("Game Over");
        Console.WriteLine(sep);
        Console.WriteLine($"The winner is {winner.Name} with {winner.NumberOfDice} chips :)");
        Console.WriteLine(sep);
        Console.WriteLine();
    }
}