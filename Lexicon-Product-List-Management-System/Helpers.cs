namespace Lexicon_Product_List_Management_System;

public static class Helpers
{
    public static decimal CalculateTotal(List<Product> products)
    {
        return products.Sum(p => p.Price);
    }
}