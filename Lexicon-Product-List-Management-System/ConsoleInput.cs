using System.Globalization;

namespace Lexicon_Product_List_Management_System;

public static class ConsoleInput
{
    public static string GetUserInput(string prompt)
    {
        ConsoleUI.RenderPrompt(prompt);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public static bool IsExit(string input)
    {
        return input.Equals("q", StringComparison.OrdinalIgnoreCase);
    }

    public static string? GetString(string prompt, string fieldName)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (!string.IsNullOrWhiteSpace(input)) return input;

            ConsoleUI.RenderError($"{fieldName} cannot be empty. Enter a value or type 'q' to cancel.");
        }
    }

    public static decimal? GetDecimal(string prompt, string fieldName = "Price", decimal max = 9_999_999m)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;

            var normalized = input.Replace(',', '.');
            if (!decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
            {
                ConsoleUI.RenderError($"'{input}' is not a valid number. Use digits only, e.g. 12.50.");
                continue;
            }

            if (value < 0)
            {
                ConsoleUI.RenderError($"{fieldName} cannot be negative.");
                continue;
            }

            if (value > max)
            {
                ConsoleUI.RenderError($"{fieldName} cannot exceed {max:N0}.");
                continue;
            }

            value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
            return value;
        }
    }

    public static int? GetInt(string prompt, int min, int max)
    {
        while (true)
        {
            var input = GetUserInput(prompt);
            if (IsExit(input)) return null;
            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                && value >= min && value <= max) return value;

            ConsoleUI.RenderError($"Enter a number between {min} and {max}.");
        }
    }

    public static void Pause(string prompt = "Press 'Enter' to continue: ") => GetUserInput(prompt);

    public static void ReportCancel(string what)
    {
        ConsoleUI.RenderWarning($"{what} canceled. Nothing was saved.");
        Pause();
    }

    public static void GenerateMenu(IReadOnlyList<(string Label, Action Action)> items, string title)
    {
        while (true)
        {
            ConsoleUI.RenderMenu(items.Select(i => i.Label).ToList(), title);

            var choice = GetInt("Select a menu item (or 'q' to quit): ", 1, items.Count);
            if (choice is null) break;

            items[choice.Value - 1].Action();
        }
    }
}