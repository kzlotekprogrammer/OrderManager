using System;

namespace OrderManager.Core.Domain.Identifiers;

public record ProductId(Guid Value)
{
    public static ProductId New()
    {
        return new ProductId(Guid.NewGuid());
    }
}