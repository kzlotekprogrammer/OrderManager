using System;
using OrderManager.BuildingBlocks;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Entities;

public class Product : Entity<ProductId>
{
    public WarehouseId WarehouseId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Amount { get; private set; }

    public Product()
    {

    }

    public Product(ProductId id, WarehouseId warehouseId, string name, decimal price, int amount) : base(id)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be less than 0");

        if (amount < 0)
            throw new ArgumentException("Amount cannot be less than 0");

        WarehouseId = warehouseId;
        Name = name;
        Price = price;
        Amount = amount;
    }

    public void UpdatePrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be less than 0");

        Price = price;
    }

    public void UpdateAmount(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be less than 0");

        Amount = amount;
    }
}