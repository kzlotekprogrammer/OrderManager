using System;

namespace OrderManager.Domain.Identifiers;

public record OrderItemId
{
    public Guid Value { get; init; }
}