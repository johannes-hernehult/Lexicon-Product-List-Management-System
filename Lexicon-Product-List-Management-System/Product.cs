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
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }


    private const string Gap = " ";

    public static string Header =>
        new string(' ', Layout.PrefixWidth) +
        $"{"Name",-Layout.NameWidth}{Gap}{"Category",Layout.CategoryWidth}{Gap}{"Price",Layout.PriceWidth}";

    public override string ToString() =>
        $"{Truncate(Name, Layout.NameWidth),-Layout.NameWidth}{Gap}" +
        $"{Truncate(Category, Layout.CategoryWidth),Layout.CategoryWidth}{Gap}" +
        $"{Price,Layout.PriceWidth:C}";

    private static string Truncate(string text, int maxLength) =>
        text.Length <= maxLength ? text : text[..(maxLength - 1)] + "…";
}