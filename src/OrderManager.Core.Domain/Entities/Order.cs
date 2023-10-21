using System;
using System.Collections.Generic;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.ValueObjects;
using OrderManager.Domain.Enums;

namespace OrderManager.Core.Domain.Entities;

public class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderItem> _items;

    public CustomerId CustomerId { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items;

    private Order()
    {
        _items = new List<OrderItem>();
    }

    public Order(OrderId id, CustomerId customerId, Address address) : base(id)
    {
        CustomerId = customerId;
        Address = address;
        Status = OrderStatus.Pending;
        _items = new List<OrderItem>();
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

    public void ChangeAddress(Address address)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Address can only be changed if order status is pending.");

        Address = address;
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