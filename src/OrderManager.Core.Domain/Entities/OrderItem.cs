using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Domain.Entities;

public class OrderItem : Entity<OrderItemId>
{
    public OrderId OrderId { get; private set; } = default!;
    public string ProductName { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    private OrderItem()
    {

    }

    public OrderItem(OrderItemId id, OrderId orderId, string productName, decimal price, int quantity) : base(id)
    {
        OrderId = orderId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}