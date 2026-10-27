namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    List<Product> Products = new List<Product>();

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void ShowProducts()
    {
        Console.WriteLine("Showing products...");
        foreach (var product in Products)
        {
            Console.WriteLine(product.ToString());
        }
    }

    public void CalculateTotal()
    {
        Console.WriteLine("Calculating total of products...");
        decimal total = 0;
        foreach (var product in Products)
        {
            Console.WriteLine(product.Price);
            total += product.Price;
        }
        Console.WriteLine($"Total of products: {total}");
    }
}