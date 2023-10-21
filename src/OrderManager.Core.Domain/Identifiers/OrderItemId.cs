using System;

namespace OrderManager.Core.Domain.Identifiers;

public record OrderItemId(Guid Value)
{
    public static OrderItemId New()
    {
        return new OrderItemId(Guid.NewGuid());
    }
}