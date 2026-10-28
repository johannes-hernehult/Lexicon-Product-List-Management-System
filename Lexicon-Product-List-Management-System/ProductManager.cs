namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    private readonly List<Product> products = new List<Product>();

    public void AddProduct()
    {
        List<Product> sessionProducts = new List<Product>();
        while (true)
        {
            var name = ConsoleInput.GetString("Product name: ");
            if (name is null) break;

            var category = ConsoleInput.GetString("Product category: ");
            if (category is null) break;

            var price = ConsoleInput.GetDecimal("Product price: ");
            if (price is null) break;

            Product newProduct = new Product(name, category, price.Value);

            products.Add(newProduct);
            sessionProducts.Add(newProduct);

            Console.Clear();
            ConsoleUI.RenderText(Product.Header, ConsoleColor.Gray);
            ConsoleUI.RenderSingleLine();
            ConsoleUI.RenderList(sessionProducts, ListStyle.Unordered, true);

            var again = ConsoleInput.GetUserInput("Press Enter to add another, or write 'exit' to stop: ");
            if (ConsoleInput.IsExit(again)) break;
        }
    }

    public void ShowProducts()
    {
        var orderedProductsByPrice = products.OrderBy(p => p.Price).ToList();
        Console.Clear();
        ConsoleUI.RenderHeading("All products");
        ConsoleUI.RenderText(Product.Header, ConsoleColor.DarkGray);
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderList(orderedProductsByPrice, ListStyle.Unordered, true);
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderText($"TOTAL PRICE: {CalculateTotal():C}");
        ConsoleUI.RenderSingleLine();
        ConsoleInput.GetUserInput("Press Enter to exit: ");
    }

    private decimal CalculateTotal()
    {
        return products.Sum(p => p.Price);
    }
}