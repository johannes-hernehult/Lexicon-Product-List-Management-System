namespace Lexicon_Product_List_Management_System;

public enum ListStyle
{
    Unordered,
    Ordered
}

public static class ConsoleUI
{
    public static void RenderText(string text, ConsoleColor color = ConsoleColor.Black, bool newLine = true)
    {
        Console.ForegroundColor = color;
        try
        {
            if (newLine) Console.WriteLine(text);
            else Console.Write(text);
        }
        finally
        {
            Console.ResetColor();
        }
    }

    public static string GetUserInput(string prompt)
    {
        RenderText(prompt, ConsoleColor.Gray, false);
        return Console.ReadLine() ?? "";
    }

    public static void RenderList<T>(IEnumerable<T> items, ListStyle style = ListStyle.Unordered)
    {
        int i = 1;
        foreach (var item in items)
        {
            var prefix = style == ListStyle.Ordered ? $"{i}. " : "- ";
            RenderText(prefix + (item?.ToString() ?? ""));
            i++;
        }
    }
}

