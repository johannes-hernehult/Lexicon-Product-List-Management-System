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

foreach (var product in tempProducts)
{
    productManager.AddProduct(product);
}

productManager.ShowProducts();

