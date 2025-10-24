using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4214_OBA_Sauliak;

public class CLI
{
    public List<Player> RetrievePlayerData()
    {
        var players = new List<Player>();
        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // to track unique names hashing should be faster

        var sep = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(sep);
        Console.WriteLine("Player Setup");
        Console.WriteLine(sep);
        Console.WriteLine("Enter player names. Add 3 - 6 players.");
        Console.WriteLine(sep);

        // ensure at least one valid unique player before asking to continue
        string PromptUniqueName()
        {
            while (true)
            {
                Console.Write("Player name: ");
                var name = Console.ReadLine();

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

                return name;
            }
        }

        // Ensure minimum 3 players
        while (players.Count < 3)
        {
            var name = PromptUniqueName();
            players.Add(new Player(name));
            existingNames.Add(name);
            Console.WriteLine(sep);
            Console.WriteLine($"Players so far: {players.Count}.");
            Console.WriteLine(sep);
        }

        // Allow up to 6 players
        while (players.Count < 6 && DecisionMorePlayers())
        {
            Console.WriteLine(sep);
            var name = PromptUniqueName();
            players.Add(new Player(name));
            existingNames.Add(name);
        }

        if (players.Count == 6)
        {
            Console.WriteLine(sep);
            Console.WriteLine("Maximum of 6 players reached.");
            Console.WriteLine(sep);
        }

        return players;
    }

    public bool DecisionMorePlayers()
    {
        Console.Write("Add more players? 1 (yes) / 2 (no): ");
        var input = Console.ReadLine()?.Trim();
        return input == "1"
               || string.Equals(input, "y", StringComparison.OrdinalIgnoreCase)
               || string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase); 
    }// non case sensitive yes or y also means yes in case the user is a bit slow

    public void PrintStatus(List<Player> players)
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

    public void PrintWinner(List<Player> players)
    {
        // With the game loop condition, there should be exactly one with chips.
        var winner = players.FirstOrDefault(p => p.HasChipsLeft)
                     ?? players.OrderByDescending(p => p.ChipCount).First();

        var sep = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine(sep);
        Console.WriteLine("Game Over");
        Console.WriteLine(sep);
        Console.WriteLine($"The winner is {winner.Name} with {winner.ChipCount} chips :)");
        Console.WriteLine(sep);
        Console.WriteLine();
    }
}