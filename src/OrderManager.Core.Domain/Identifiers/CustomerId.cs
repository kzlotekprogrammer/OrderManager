using System;

namespace OrderManager.Domain.Identifiers;

public record CustomerId
{
    public Guid Value { get; init; }
}