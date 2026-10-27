namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    List<Product> Products = new List<Product>();

    public void AddProduct()
    {
        while(true)
        {
            string productName = ConsoleUI.GetUserInput("Product Name: ");
            if (productName == "exit") break;
            
            string productCategory = ConsoleUI.GetUserInput("Product category: ");
            if (productCategory == "exit") break;
            
            string priceInput = ConsoleUI.GetUserInput("Product price: ");
            if (priceInput == "exit") break;

            if (!decimal.TryParse(priceInput, out decimal price))
            {
                ConsoleUI.RenderText("Invalid price, try again.", ConsoleColor.Red);
                continue;
            }
            
            Products.Add(new Product(productName, productCategory, price));
            
            //Ask user to add another or exit
            string userInput = ConsoleUI.GetUserInput("Press 'Enter' to add another product. Write 'Exit' to exit.");
            if (userInput == "no") break;
        };
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