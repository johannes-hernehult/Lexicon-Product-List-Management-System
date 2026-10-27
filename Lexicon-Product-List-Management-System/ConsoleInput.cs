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

    public static bool IsExit(string input) =>
        input.Equals("exit", StringComparison.OrdinalIgnoreCase);
}