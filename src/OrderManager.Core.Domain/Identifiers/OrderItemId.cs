using System;

namespace OrderManager.Domain.Identifiers;

public record OrderItemId(Guid Value)
{
    public static OrderItemId New()
    {
        return new OrderItemId(Guid.NewGuid());
    }
}