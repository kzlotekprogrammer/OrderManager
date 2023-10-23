using MediatR;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Events;

public record ProductPriceChangedEvent : INotification
{
    public ProductId ProductId { get; init; } = default!;
    public decimal NewPrice { get; init; }
}
