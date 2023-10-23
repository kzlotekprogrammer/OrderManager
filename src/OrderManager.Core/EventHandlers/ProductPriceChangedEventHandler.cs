using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Events;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Core.EventHandlers;

public class ProductPriceChangedEventHandler : INotificationHandler<ProductPriceChangedEvent>
{
    private readonly IOrderRepository _orderRepository;

    public ProductPriceChangedEventHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(ProductPriceChangedEvent @event, CancellationToken cancellationToken)
    {
        List<Order> affectedOrders = await _orderRepository.GetOrdersAffectedByProductPriceChangeAsync(@event.ProductId);

        foreach (Order order in affectedOrders)
        {
            order.UpdateOrderItemPrice(@event.ProductId, @event.NewPrice);

            await _orderRepository.UpdateAsync(order);
        }
    }
}
