using System.Diagnostics;

namespace Lexicon_Product_List_Management_System;

public static class ConsoleInput
{
    public static string GetUserInput(string prompt)
    {
        ConsoleUI.RenderText(prompt, ConsoleColor.Gray, false);
        return Console.ReadLine() ?? "";
    }

    public static string? GetString(string prompt)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (input != "") return input;

            ConsoleUI.RenderText("Cannot be empty, try again.", ConsoleColor.Red);
        }
    }

    public static decimal? GetDecimal(string prompt)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (decimal.TryParse(input, out var value) && value >= 0) return value;

            ConsoleUI.RenderText("Invalid number, try again.", ConsoleColor.Red);
        }
    }

    public static int? GetInt(string prompt, int min, int max)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (int.TryParse(input, out int value) && value >= min && value <= max) return value;

            ConsoleUI.RenderText($"Enter a number between {min} and {max}.", ConsoleColor.Red);
        }
    }

    public static bool IsExit(string input)
    {
        return input.Equals("exit", StringComparison.OrdinalIgnoreCase);
    }

    public static void GenerateMenu(IReadOnlyList<(string Label, Action Action)> items, string title)
    {
        while (true)
        {
            Console.Clear();
            ConsoleUI.RenderHeading(title);
            ConsoleUI.RenderList(items.Select(i => i.Label).ToList(), ListStyle.Ordered);

            var choice = GetInt("Select a menu item (or 'exit'): ", 1, items.Count);
            if (choice is null) break;

            items[choice.Value - 1].Action();

//            ConsoleUI.RenderText("Press Enter to continue...", ConsoleColor.Gray);
//            Console.ReadLine();
        }
    }
}