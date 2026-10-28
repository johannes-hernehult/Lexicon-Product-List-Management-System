namespace Lexicon_Product_List_Management_System;

public class Product
{
    public Product(string name, string category, decimal price)
    {
        Id = Guid.NewGuid();
        Category = category;
        Name = name;
        Price = price;
    }


    public Guid Id { get; }
    public string Name { get; }
    public string Category { get; }
    public decimal Price { get; }

    public static string Header =>
        new string(' ', Layout.PrefixWidth) +
        $"{"Name",-Layout.NameWidth} {"Category",Layout.CategoryWidth} {"Price",Layout.PriceWidth}";

    public override string ToString() =>
        $"{Truncate(Name, Layout.NameWidth),-Layout.NameWidth} " +
        $"{Truncate(Category, Layout.CategoryWidth),Layout.CategoryWidth} " +
        $"{Price,Layout.PriceWidth:C}";

    private static string Truncate(string text, int maxLength) =>
        text.Length <= maxLength ? text : text[..(maxLength - 1)] + "…";
}