using System.Globalization;
using System.Diagnostics;

namespace Lexicon_Product_List_Management_System;

public static class ConsoleInput
{
    public static string GetUserInput(string prompt)
    {
        ConsoleUI.RenderPrompt(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static string? GetString(string prompt)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (!string.IsNullOrWhiteSpace(input)) return input;
            
            ConsoleUI.RenderError("Cannot be empty, try again.");
        }
    }

    public static decimal? GetDecimal(string prompt)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;

            var normalized = input.Replace(',', '.');
            if (decimal.TryParse(normalized, NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture, out var value) && value >= 0)
                return value;

            ConsoleUI.RenderError("Invalid number, try again (e.g. 12.50).");
        }
    }

    public static int? GetInt(string prompt, int min, int max)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (int.TryParse(input, out int value) && value >= min && value <= max) return value;

            ConsoleUI.RenderError($"Enter a number between {min} and {max}.");
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
            ConsoleUI.RenderMenu(items.Select(i => i.Label).ToList(), title);

            var choice = GetInt("Select a menu item (or 'exit'): ", 1, items.Count);
            if (choice is null) break;

            items[choice.Value - 1].Action();
        }
    }
    
    public static void ReportCancel()
    {
        ConsoleUI.RenderWarning("Action canceled.");
        ConsoleInput.GetUserInput("Press 'Enter' to continue");
    }
    
    public static void Pause(string prompt = "Press 'Enter' to continue: ") => GetUserInput(prompt);
}