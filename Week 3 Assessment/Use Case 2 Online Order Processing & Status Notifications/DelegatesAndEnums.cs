namespace OrderProcessingSystem
{
    // Requirement 2: Enum for strict status control
    public enum OrderStatus
    {
        Created,
        Paid,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    // Requirement 10 & 16: Custom Delegate
    // This signature allows subscribers to know WHICH order changed, and WHAT changed.
    public delegate void OrderStatusHandler(Models.Order order, OrderStatus oldStatus, OrderStatus newStatus);
}