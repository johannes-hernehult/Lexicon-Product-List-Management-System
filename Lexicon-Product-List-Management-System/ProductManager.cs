namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    List<Product> Products = new List<Product>();

    public void AddProduct()
    {
        Console.WriteLine("Adding product...");
    }
    
    public void ShowProducts()
    {
        Console.WriteLine("Showing products...");
    }

    public void CalculateTotal()
    {
        Console.WriteLine("Calculating total of products...");
    }
}