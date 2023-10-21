using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Entities;

public class OrderItem : Entity<OrderItemId>
{
    public OrderId OrderId { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;
    public string ProductName { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    private OrderItem()
    {

    }

    public OrderItem(OrderItemId id, OrderId orderId, ProductId productId, string productName, decimal price, int quantity) : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}