using Lexicon_Product_List_Management_System;

Console.WriteLine("Product List Management System");

ProductManager productManager = new ProductManager();

var mainMenu = new List<(string, Action)>
{
    ("Add new product", productManager.AddProduct),
    ("See all products", productManager.ShowProducts),
    ("Search for products", productManager.SearchProducts),
};

try
{
    ConsoleInput.GenerateMenu(mainMenu, "Main Menu");
}
catch (Exception ex)
{
    ConsoleUI.RenderError($"Fatal error: {ex.Message}");
}