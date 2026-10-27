using Lexicon_Product_List_Management_System;

Console.WriteLine("Product List Management System");

var tempProducts = new List<Product>
{
    new Product("electronic", "Laptop", 300),
    new Product("food", "Cake", 50),
    new Product("electronic", "Monitor", 400),
    new Product("furniture", "Chair", 600),
    new Product("food", "Pizza", 100),
    new Product("food", "Chocolate Cake", 40),
    new Product("electronic", "Headphones", 200),
    new Product("furniture", "Table", 600),
    new Product("furniture", "Sofa", 500),
    new Product("food", "Chocolate", 10),
};

ProductManager productManager = new ProductManager();

foreach (var product in tempProducts)
{
    productManager.AddProduct(product);
}

productManager.ShowProducts();