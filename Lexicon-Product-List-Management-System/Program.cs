using Lexicon_Product_List_Management_System;

Console.WriteLine("Product List Management System");

ProductManager productManager = new ProductManager();

var mainMenu = new List<(string, Action)>
{
    ("Add new product", productManager.AddProduct),
    ("See all products", productManager.ShowProducts),
};

ConsoleInput.GenerateMenu(mainMenu, "Main Menu");


/*
 * TODO:
 * - Input validation and Error handling
 * -
 */