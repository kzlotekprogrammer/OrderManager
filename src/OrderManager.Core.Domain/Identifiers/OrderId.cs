using System;

namespace OrderManager.Core.Domain.Identifiers;

public record OrderId(Guid Value)
{
    public static OrderId New()
    {
        return new OrderId(Guid.NewGuid());
    }
}