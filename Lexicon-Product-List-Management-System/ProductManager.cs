namespace Lexicon_Product_List_Management_System;

public class ProductManager
{
    private readonly List<Product> products = new List<Product>();

    public void AddProduct()
    {
        var sessionProducts = new List<Product>();

        while (true)
        {
            var product = PromptForProduct();
            if (product is null)
            {
                ConsoleInput.ReportCancel();
                return;
            }

            products.Add(product);
            sessionProducts.Add(product);
            RenderSessionProducts(sessionProducts);

            var again = ConsoleInput.GetUserInput("Press 'Enter' to add another, or write 'exit' to stop: ");
            if (ConsoleInput.IsExit(again)) return;
        }
    }

    private static Product? PromptForProduct()
    {
        var name = ConsoleInput.GetString("Product name: ");
        if (name is null) return null;

        var category = ConsoleInput.GetString("Product category: ");
        if (category is null) return null;

        var price = ConsoleInput.GetDecimal("Product price: ");
        if (price is null) return null;

        return new Product(name, category, price.Value);
    }

    private static void RenderSessionProducts(IReadOnlyList<Product> items)
    {
        Console.Clear();
        ConsoleUI.RenderText(Product.Header, ConsoleColor.Gray);
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderList(items, ListStyle.Unordered, true);
    }

    public void ShowProducts()
    {
        if (products.Count == 0)
        {
            ConsoleUI.RenderText("No products found.", ConsoleColor.Yellow);
            ConsoleInput.GetUserInput("Press 'Enter' to exit: ");
            return;
        }

        var orderedProductsByPrice = products.OrderBy(p => p.Price).ToList();
        Console.Clear();
        ConsoleUI.RenderHeading("All products");
        ConsoleUI.RenderText(Product.Header, ConsoleColor.DarkGray);
        ConsoleUI.RenderSingleLine(color: ConsoleColor.Gray);
        ConsoleUI.RenderList(orderedProductsByPrice, ListStyle.Unordered, true);
        RenderTotalPrice();
        ConsoleInput.GetUserInput("Press 'Enter' to exit: ");
    }

    private decimal CalculateTotal()
    {
        return products.Sum(p => p.Price);
    }

    private void RenderTotalPrice()
    {
        const string label = "  TOTAL PRICE: ";
        var total = CalculateTotal().ToString("C").PadLeft(Layout.RowWidth - label.Length);
        
        ConsoleUI.RenderSingleLine();
        ConsoleUI.RenderText(label + total);
        ConsoleUI.RenderDoubleLine();
    }
}