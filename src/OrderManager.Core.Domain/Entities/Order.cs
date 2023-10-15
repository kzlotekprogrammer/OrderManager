using System;
using System.Collections.Generic;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Domain.Enums;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Domain.Entities;

public class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderItem> _items;

    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items;

    public Order(OrderId id, Guid customerId, List<OrderItem> items) : base(id)
    {
        CustomerId = customerId;
        Status = OrderStatus.Pending;
        _items = items;
    }

    public void AddItem(OrderItem item)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Items can only be added to pending orders.");

        _items.Add(item);
    }

    public void RemoveItem(OrderItem item)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Items can only be removed from pending orders.");

        _items.Remove(item);
    }

    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Order can only be confirmed if it is pending.");
            
        Status = OrderStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Order can only be canceled if it is pending.");

        Status = OrderStatus.Canceled;
    }

    public decimal CalculateTotalAmount()
    {
        decimal totalAmount = 0;

        foreach (OrderItem item in _items)
        {
            totalAmount += item.Price * item.Quantity;
        }

        return totalAmount;
    }
}