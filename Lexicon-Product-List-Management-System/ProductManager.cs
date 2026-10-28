namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    List<Product> products = new List<Product>();

    public void AddProduct()
    {
        List<Product> sessionProcucts = new List<Product>();
        while (true)
        {
            var name = ConsoleInput.GetString("Product name: ");
            if (name is null) break;

            var category = ConsoleInput.GetString("Product category: ");
            if (category is null) break;

            var price = ConsoleInput.GetDecimal("Product price: ");
            if (price is null) break;

            products.Add(new Product(name, category, price.Value));
            sessionProcucts.Add(products.Last());
            
            Console.Clear();
            ConsoleUI.RenderText(Product.Header, ConsoleColor.Gray);
            ConsoleUI.RenderSingleLine();
            ConsoleUI.RenderList(sessionProcucts, ListStyle.Unordered, true);
            
            var again = ConsoleInput.GetUserInput("Press Enter to add another, or write 'exit' to stop: ");
            if (ConsoleInput.IsExit(again)) break;
        }
    }

    public void ShowProducts()
    {
        ConsoleUI.RenderHeading("ALL PRODUCTS");
        ConsoleUI.RenderList(products);
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderText($"TOTAL PRICE: {CalculateTotal():C}");
        ConsoleUI.RenderSingleLine();
        ConsoleInput.GetUserInput("Press Enter to exit: ");
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }

        return total;
    }
}