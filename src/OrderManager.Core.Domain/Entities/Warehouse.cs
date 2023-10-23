using System;
using System.Collections.Generic;
using System.Linq;
using OrderManager.BuildingBlocks;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Entities;

public class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<Product> _products;
    public IReadOnlyCollection<Product> Products => _products;

    public Warehouse()
    {
        _products = new List<Product>();
    }

    public Warehouse(WarehouseId id, List<Product> products) : base(id)
    {
        _products = products;
    }

    public void AddProduct(Product product)
    {
        if (_products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException($"Warehouse already contains product with id={product.Id.Value}");

        _products.Add(product);
    }

    public void UpdatePrice(ProductId productId, decimal amount)
    {
        Product? product = _products.FirstOrDefault(p => p.Id == productId);
        if (product is null)
            throw new InvalidOperationException($"Warehouse does not contains product with id={productId.Value}");

        product.UpdatePrice(amount);
    }

    public void UpdateAmount(ProductId productId, int amount)
    {
        Product? product = _products.FirstOrDefault(p => p.Id == productId);
        if (product is null)
            throw new InvalidOperationException($"Warehouse does not contains product with id={productId.Value}");

        product.UpdateAmount(amount);
    }
}
