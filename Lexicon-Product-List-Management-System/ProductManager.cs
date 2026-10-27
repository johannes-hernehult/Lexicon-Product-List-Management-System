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
        ConsoleUI.RenderHeading("ALL PRODUCTS");
        ConsoleUI.RenderList(Products);
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderText($"TOTAL PRICE: {CalculateTotal():C}");
        ConsoleUI.RenderSingleLine();
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in Products)
        {
            total += product.Price;
        }

        return total;
    }
}