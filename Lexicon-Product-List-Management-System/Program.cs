using Lexicon_Product_List_Management_System;

Console.WriteLine("Product List Management System");

var tempProducts = new List<Product>
{
    new Product("Laptop", "electronic", 300),
    new Product("Cake", "food", 50),
    new Product("Monitor", "electronic", 400),
    new Product("Chair", "furniture", 600),
    new Product("Pizza", "food", 100),
    new Product("Chocolate Cake", "food", 40),
    new Product("Headphones", "electronic", 200),
    new Product("Table", "furniture", 600),
    new Product("Sofa", "furniture", 500),
    new Product("Chocolate", "food", 10),
};

ProductManager productManager = new ProductManager();

var mainMenu = new List<(string, Action)>
{
    ("Add new product", productManager.AddProduct),
    ("See all products", productManager.ShowProducts),
};

ConsoleInput.GenerateMenu(mainMenu, "Main Menu");


/*
 * TODO:
 * 3. Implement main menu
 * 2. Implement error handling
 *      a. Look over all classes, methods and functions to see where things can go wrong (tests ?)
 * 4. Render all products after adding one product???
 * 5. Handling negative values?
 */