using OrderManager.Core.Dtos;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Core.Extensions;

public static class MappingExtensions
{
    public static OrderItem Map(this OrderItemDto orderItemDto, OrderId orderId)
    {
        return new OrderItem(OrderItemId.New(), orderId, orderItemDto.ProductName, orderItemDto.Price, orderItemDto.Quantity);
    }
}
