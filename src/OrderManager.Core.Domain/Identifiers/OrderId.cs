using System;

namespace OrderManager.Domain.Identifiers;

public record OrderId(Guid Value)
{
    public static OrderId New()
    {
        return new OrderId(Guid.NewGuid());
    }
}