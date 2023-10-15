using System;

namespace OrderManager.Domain.Identifiers;

public record CustomerId(Guid Value)
{
    public static CustomerId New()
    {
        return new CustomerId(Guid.NewGuid());
    }
}