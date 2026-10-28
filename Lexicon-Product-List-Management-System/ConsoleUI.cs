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

    public static void RenderList<T>(IReadOnlyList<T> items, ListStyle style = ListStyle.Unordered, bool isAlternatingColor = false)
    {
        var color = ConsoleColor.Black;
        
        for (int i = 0; i < items.Count; i++)
        {
            var prefix = style == ListStyle.Ordered ? $"{i + 1}. " : "- ";
            if(isAlternatingColor)
            {
                color = i % 2 == 0 ? ConsoleColor.Black : ConsoleColor.Gray;
            }

            RenderText(prefix + (items[i]?.ToString() ?? ""), color);
        }
    }

    public static void RenderHeading(string heading)
    {
        RenderText("");
        RenderText(
            "".PadRight(15, '=')
            + " " + heading + " " +
            "".PadLeft(18, '='),
            ConsoleColor.Gray);
    }

    public static void RenderSingleLine()
    {
        Console.WriteLine("-----------------------------------------------");
    }
    
    public static void RenderPrompt(string prompt)
    {
        RenderText(prompt, ConsoleColor.Cyan, false);
    }

    public static void RenderError(string message)
    {
        RenderText(message, ConsoleColor.Red);
    }

    public static void RenderWarning(string message)
    {
        RenderText(message, ConsoleColor.Yellow);
    }

    public static void RenderMenu(IReadOnlyList<string> labels, string title)
    {
        Console.Clear();
        RenderHeading(title);
        RenderList(labels, ListStyle.Ordered);
    }
    
}