﻿using Curso_1.Entities;
using Curso_1.Entities.Enums;
using System;
using System.Globalization;

namespace Curso_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);
            string txt = OrderStatus.PendingPayment.ToString();
            Console.WriteLine(txt);
            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
            Console.WriteLine(os);
        }

    }
}

