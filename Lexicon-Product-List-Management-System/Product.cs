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
    
    public override string ToString() => $"{Name,-18} {Category,-13} {Price,12:C}";
    
}