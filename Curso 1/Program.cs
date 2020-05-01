
using System;
using System.Globalization;
using Curso_1.Entities.Enums;
using Curso_1.Entities;



namespace Curso_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order;
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MMM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            DateTime moment = DateTime.Now;
            Console.Write("Status: ");
            Client c = new Client(name, email, birthdate);
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Product prod = new Product();
            order = new Order(moment, status, c, prod);


            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " item data:");
                Console.Write("Product name: ");
                string nameproduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceproduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                prod = new Product(nameproduct, priceproduct);
                OrderItem ord = new OrderItem(quantity, priceproduct, prod);
                order.AddItem(ord);
            }

            Console.WriteLine();

            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);



        }
    }
}

