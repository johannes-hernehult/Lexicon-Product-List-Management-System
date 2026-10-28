namespace Lexicon_Product_List_Management_System;

public enum ListStyle
{
    Unordered,
    Ordered
}

public static class ConsoleUI
{
    // Core primitive
    public static void RenderText(string text, ConsoleColor? color = null, bool newLine = true)
    {
        if (color is not null) Console.ForegroundColor = color.Value;
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

    public static void RenderPrompt(string prompt)
    {
        RenderText(prompt, ConsoleColor.DarkGreen, false);
    }

    public static void RenderError(string message)
    {
        RenderText(message, ConsoleColor.Red);
    }

    public static void RenderWarning(string message)
    {
        RenderText(message, ConsoleColor.Yellow);
    }

    public static void RenderSuccess(string message)
    {
        RenderText(message, ConsoleColor.Green);
    }

    public static void RenderHeading(string heading, int width = Layout.RowWidth)
    {
        var text = $" {heading} ";
        var left = Math.Max(0, (width - text.Length) / 2);
        var right = Math.Max(0, width - text.Length - left);

        RenderText("");
        RenderText(new string('=', left) + text + new string('=', right), ConsoleColor.Gray);
    }

    public static void RenderSingleLine(int width = Layout.RowWidth, ConsoleColor? color = null)
    {
        RenderText(new string('-', width), color);
    }

    public static void RenderDoubleLine(int width = Layout.RowWidth, ConsoleColor? color = null)
    {
        RenderText(new string('=', width), color);
    }

    public static void RenderList<T>(IReadOnlyList<T> items, ListStyle style = ListStyle.Unordered,
        bool isAlternatingColor = false, ConsoleColor? overrideColor = null)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var prefix = style == ListStyle.Ordered ? $"{i + 1}. " : "- ";

            ConsoleColor? color = overrideColor ?? (isAlternatingColor && i % 2 == 1 ? ConsoleColor.Gray : null);

            RenderText(prefix + (items[i]?.ToString() ?? ""), color);
        }
    }

    public static void RenderMenu(IReadOnlyList<string> labels, string title)
    {
        Console.Clear();
        RenderHeading(title);
        RenderList(labels, ListStyle.Ordered);
    }

    public static void RenderTotalPrice(List<Product> products)
    {
        const string label = "  TOTAL PRICE: ";
        var total = Helpers.CalculateTotal(products).ToString("C").PadLeft(Layout.RowWidth - label.Length);

        RenderSingleLine();
        RenderText(label + total);
        RenderDoubleLine();
    }
}