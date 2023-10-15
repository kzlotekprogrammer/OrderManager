using System;

namespace OrderManager.Domain.Identifiers;

public record OrderId
{
    public Guid Value { get; init; }
}