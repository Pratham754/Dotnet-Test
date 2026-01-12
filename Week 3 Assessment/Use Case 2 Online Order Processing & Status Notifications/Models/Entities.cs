using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessingSystem.Models
{
    #region Product

    /// <summary>
    /// Represents a product available for ordering.
    /// </summary>
    public class Product
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        public Product(int id, string name, decimal price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        #endregion
    }

    #endregion

    #region Order Item

    /// <summary>
    /// Represents an item within an order.
    /// </summary>
    public class OrderItem
    {
        #region Properties

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal => Product.Price * Quantity;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new order item instance.
        /// </summary>
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        #endregion
    }

    #endregion

    #region Customer

    /// <summary>
    /// Represents a customer placing orders.
    /// </summary>
    public class Customer
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new customer instance.
        /// </summary>
        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        #endregion
    }

    #endregion

    #region Status Log

    /// <summary>
    /// Represents a status change entry in order history.
    /// </summary>
    public class StatusLog
    {
        #region Properties

        public DateTime Timestamp { get; set; }

        public OrderStatus Status { get; set; }
        public string Notes { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Returns a formatted history log entry.
        /// </summary>
        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Status}: {Notes}";
        }

        #endregion
    }

    #endregion

    #region Order

    /// <summary>
    /// Represents a customer order and its lifecycle.
    /// </summary>
    public class Order
    {
        #region Properties

        public int Id { get; private set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public List<StatusLog> History { get; private set; } = new List<StatusLog>();

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new order instance.
        /// </summary>
        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            AddHistoryLog(OrderStatus.Created, "Order Created");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a product item to the order.
        /// </summary>
        public void AddItem(Product p, int qty)
        {
            Items.Add(new OrderItem(p, qty));
        }

        /// <summary>
        /// Calculates the total value of the order.
        /// </summary>
        public decimal CalculateTotal()
        {
            return Items.Sum(i => i.SubTotal);
        }

        /// <summary>
        /// Adds a status entry to the order history.
        /// </summary>
        public void AddHistoryLog(OrderStatus status, string notes)
        {
            History.Add(new StatusLog
            {
                Timestamp = DateTime.Now,
                Status = status,
                Notes = notes
            });
        }

        #endregion
    }

    #endregion
}