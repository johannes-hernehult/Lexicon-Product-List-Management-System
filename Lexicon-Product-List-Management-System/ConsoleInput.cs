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

    public static string? GetString(string prompt, string fieldName)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (!string.IsNullOrWhiteSpace(input)) return input;

            ConsoleUI.RenderError($"{fieldName} cannot be empty. Enter a value or type 'exit' to cancel.");
        }
    }

    public static decimal? GetDecimal(string prompt, decimal max = 9_999_999m)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;

            var normalized = input.Replace(',', '.');
            if (!decimal.TryParse(normalized, out var value))
            {
                ConsoleUI.RenderError($"'{input}' is not a valid number. Use digits only, e.g. 12.50.");
                continue;
            }

            if (value < 0)
            {
                ConsoleUI.RenderError("Price cannot be negative.");
                continue;
            }

            if (value > max)
            {
                ConsoleUI.RenderError($"Price cannot exceed {max:N0}.");
                continue;
            }

            return value;
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

    public static void ReportCancel(string what)
    {
        ConsoleUI.RenderWarning($"{what} canceled. Nothing was saved.");
        Pause();
    }

    public static void Pause(string prompt = "Press 'Enter' to continue: ") => GetUserInput(prompt);
}