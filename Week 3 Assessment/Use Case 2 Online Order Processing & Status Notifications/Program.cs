using System;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem
{
    #region Program Entry Point

    /// <summary>
    /// Application entry point for the Order Processing System.
    /// </summary>
    class Program
    {
        #region Main Method

        /// <summary>
        /// Executes sample order processing workflow.
        /// </summary>
        static void Main(string[] args)
        {
            // Setup sample products and customers
            var p1 = new Product(1, "Laptop", 1000m, "Electronics");
            var p2 = new Product(2, "Mouse", 20m, "Electronics");
            var c1 = new Customer(101, "Pratham", "alice@test.com");
            var c2 = new Customer(102, "Prathamesh", "bob@test.com");

            // Initialize services
            OrderService svc = new OrderService();
            NotificationService notifier = new NotificationService();

            // Attach subscribers (multicast delegate)
            svc.OnStatusChanged += notifier.NotifyCustomer;
            svc.OnStatusChanged += notifier.NotifyLogistics;

            // Create and register orders
            Order order1 = new Order(5001, c1);
            order1.AddItem(p1, 1);
            order1.AddItem(p2, 2);
            svc.RegisterOrder(order1);

            Order order2 = new Order(5002, c2);
            order2.AddItem(p1, 1);
            svc.RegisterOrder(order2);

            Console.WriteLine("\n--- Starting Order Processing ---\n");

            // Happy path for Order 1
            svc.UpdateStatus(5001, OrderStatus.Paid);
            svc.UpdateStatus(5001, OrderStatus.Processing);
            svc.UpdateStatus(5001, OrderStatus.Shipped);

            // Invalid transition test for Order 2
            Console.WriteLine("\n--- Testing Invalid Transition (Order 2) ---");
            svc.UpdateStatus(5002, OrderStatus.Shipped);

            // Final report
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("FINAL ORDER REPORT");
            Console.WriteLine(new string('=', 50));

            PrintOrder(order1);
            PrintOrder(order2);

            Console.ReadKey();
        }

        #endregion

        #region Reporting

        /// <summary>
        /// Prints detailed order information including history timeline.
        /// </summary>
        static void PrintOrder(Order o)
        {
            Console.WriteLine($"\nOrder #{o.Id} | Status: {o.Status} | Total: {o.CalculateTotal():C}");
            Console.WriteLine("History Timeline:");
            foreach (var log in o.History)
            {
                Console.WriteLine($" - {log}");
            }
        }

        #endregion
    }

    #endregion
}