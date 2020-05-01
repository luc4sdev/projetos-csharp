using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Curso_1.Entities.Enums;
using Curso_1.Entities;

namespace Curso_1.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client, Product product)
        {
            Moment = moment;
            Status = status;
            Client = client;
            Product = product;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in OrderItems)
            {
                total = total + item.SubTotal();

            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items: ");
            foreach (OrderItem item in OrderItems)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
               
            }
            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
