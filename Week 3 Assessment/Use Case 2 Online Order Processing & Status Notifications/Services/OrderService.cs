using System;
using System.Collections.Generic;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    #region Order Service

    /// <summary>
    /// Handles order registration, status updates, and workflow enforcement.
    /// </summary>
    public class OrderService
    {
        #region Fields

        public OrderStatusHandler OnStatusChanged;
        private Dictionary<int, Order> _orderRepository = new Dictionary<int, Order>();

        #endregion

        #region Methods

        /// <summary>
        /// Registers a new order into the system.
        /// </summary>
        public void RegisterOrder(Order order)
        {
            if (!_orderRepository.ContainsKey(order.Id))
            {
                _orderRepository.Add(order.Id, order);
                Console.WriteLine($"[System] Order {order.Id} registered for {order.Customer.Name}.");
            }
        }

        /// <summary>
        /// Updates the status of an order if the transition is valid.
        /// </summary>
        public bool UpdateStatus(int orderId, OrderStatus newStatus)
        {
            if (!_orderRepository.ContainsKey(orderId))
            {
                Console.WriteLine("Order not found!");
                return false;
            }

            Order order = _orderRepository[orderId];
            OrderStatus oldStatus = order.Status;

            // Validate state transition
            if (!IsValidTransition(oldStatus, newStatus))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"[ERROR] Cannot change Order {orderId} from {oldStatus} to {newStatus}. Violation of workflow.");
                Console.ResetColor();
                return false;
            }

            // Update state and log
            order.Status = newStatus;
            order.AddHistoryLog(newStatus, "Status updated via Service");

            // Trigger notifications via delegate
            OnStatusChanged?.Invoke(order, oldStatus, newStatus);

            return true;
        }

        /// <summary>
        /// Determines if a status transition is valid according to workflow rules.
        /// </summary>
        private bool IsValidTransition(OrderStatus current, OrderStatus next)
        {
            if (current == OrderStatus.Cancelled) return false;
            if (next == OrderStatus.Cancelled) return true;

            // Strict workflow: Created -> Paid -> Processing -> Shipped -> Delivered
            return current switch
            {
                OrderStatus.Created => next == OrderStatus.Paid,
                OrderStatus.Paid => next == OrderStatus.Processing,
                OrderStatus.Processing => next == OrderStatus.Shipped,
                OrderStatus.Shipped => next == OrderStatus.Delivered,
                _ => false
            };
        }

        #endregion
    }

    #endregion
}
