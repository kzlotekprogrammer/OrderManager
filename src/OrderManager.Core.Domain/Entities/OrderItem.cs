using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Domain.Entities;

public class OrderItem : Entity<OrderItemId>
{
    public string ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(OrderItemId id, string productName, decimal price, int quantity) : base(id)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}