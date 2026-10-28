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
                ConsoleInput.ReportCancel("Add product");
                return;
            }

            products.Add(product);
            sessionProducts.Add(product);
            RenderSessionProducts(sessionProducts);

            var again = ConsoleInput.GetUserInput("Press 'Enter' to add another, or write 'exit' to stop: ");
            if (ConsoleInput.IsExit(again)) return;
        }
    }

    public void ShowProducts()
    {
        if (products.Count == 0)
        {
            RenderNoProducts();
            return;
        }

        var orderedProductsByPrice = products.OrderBy(p => p.Price).ToList();
        Console.Clear();
        ConsoleUI.RenderHeading("All products");
        RenderTableHeader();
        ConsoleUI.RenderList(orderedProductsByPrice, ListStyle.Unordered, true);
        ConsoleUI.RenderTotalPrice(products);
        ConsoleInput.Pause();
    }

    public void SearchProducts()
    {
        if (products.Count == 0)
        {
            RenderNoProducts();
            return;
        }

        Console.Clear();
        ConsoleUI.RenderHeading("Search for products");

        while (true)
        {
            var searchTerm = ConsoleInput.GetString("Search ('exit' to go back): ", "Search term");
            if (searchTerm is null) break;

            var results = products
                .Where(p =>
                    p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count == 0)
            {
                ConsoleUI.RenderText("No products found.", ConsoleColor.Yellow);
                continue;
            }

            ConsoleUI.RenderHeading("Search results");
            RenderTableHeader();
            ConsoleUI.RenderList(results, ListStyle.Unordered, overrideColor: ConsoleColor.Green);
        }
    }

    private static Product? PromptForProduct()
    {
        var name = ConsoleInput.GetString("Product name: ", "Product name");
        if (name is null) return null;

        var category = ConsoleInput.GetString("Product category: ", "Product category");
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

    private static void RenderTableHeader()
    {
        ConsoleUI.RenderText(Product.Header, ConsoleColor.DarkGray);
        ConsoleUI.RenderSingleLine(color: ConsoleColor.Gray);
    }

    private static void RenderNoProducts()
    {
        ConsoleUI.RenderText("No products found.", ConsoleColor.Yellow);
        ConsoleInput.Pause("Press 'Enter' to exit: ");
    }
}