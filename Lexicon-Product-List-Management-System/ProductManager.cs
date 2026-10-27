namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    List<Product> Products = new List<Product>();

    public void AddProduct()
    {
        while (true)
        {
            var name = ConsoleInput.GetString("Product name: ");
            if (name is null) break;

            var category = ConsoleInput.GetString("Product category: ");
            if (category is null) break;

            var price = ConsoleInput.GetDecimal("Product price: ");
            if (price is null) break;

            Products.Add(new Product(name, category, price.Value));

            var again = ConsoleInput.GetUserInput("Press Enter to add another, or write 'exit' to stop: ");
            if (ConsoleInput.IsExit(again)) break;
        }
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