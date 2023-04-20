using System;
using System.Collections.Generic;

namespace ShoppingKart
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class ShoppingCart
    {
        public List<Product> products = new List<Product>();

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public void PrintCart()
        {
            Console.WriteLine("Your products in shopping cart:");
            foreach (var p in products)
            {
                Console.WriteLine("- product: {0} {1}e", p.Name, p.Price);
            }
            Console.WriteLine("There are {0} products in the shopping cart.", products.Count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart();
            cart.AddProduct(new Product("Milk", 1.4));
            cart.AddProduct(new Product("Bread", 2.2));
            cart.AddProduct(new Product("Butter", 3.2));
            cart.AddProduct(new Product("Cheese", 4.2));
            cart.PrintCart();

            Console.ReadLine(); // wait for user input
        }
    }
}