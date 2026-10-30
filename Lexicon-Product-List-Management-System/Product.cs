namespace Lexicon_Product_List_Management_System;

public class Product(string name, string category, decimal price)
{
    public static string Header =>
        new string(' ', Layout.PrefixWidth) +
        $"{"Name",-Layout.NameWidth} {"Category",Layout.CategoryWidth} {"Price",Layout.PriceWidth}";

    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; } = name;
    public string Category { get; } = category;
    public decimal Price { get; } = price;

    public override string ToString() =>
        $"{Truncate(Name, Layout.NameWidth),-Layout.NameWidth} " +
        $"{Truncate(Category, Layout.CategoryWidth),Layout.CategoryWidth} " +
        $"{Price,Layout.PriceWidth:C}";

    private static string Truncate(string text, int maxLength) =>
        text.Length <= maxLength ? text : text[..(maxLength - 1)] + "…";
}