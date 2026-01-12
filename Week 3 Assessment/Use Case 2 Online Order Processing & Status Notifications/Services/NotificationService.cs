using System;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    #region Notification Service

    /// <summary>
    /// Handles order status change notifications.
    /// </summary>
    public class NotificationService
    {
        #region Methods

        /// <summary>
        /// Sends order status update notification to the customer.
        /// </summary>
        public void NotifyCustomer(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine(
                $"   >>> [Email Service] To: {order.Customer.Email} | Msg: Your order #{order.Id} is now {newStatus}.");
        }

        /// <summary>
        /// Sends logistics-related notifications based on order status.
        /// </summary>
        public void NotifyLogistics(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
            {
                Console.WriteLine(
                    $"   >>> [Logistics API] Dispatching truck for Order #{order.Id}. Total Weight: {order.Items.Count * 2}kg.");
            }
            else if (newStatus == OrderStatus.Delivered)
            {
                Console.WriteLine(
                    $"   >>> [Logistics API] Closing ticket for Order #{order.Id}.");
            }
        }

        #endregion
    }

    #endregion
}