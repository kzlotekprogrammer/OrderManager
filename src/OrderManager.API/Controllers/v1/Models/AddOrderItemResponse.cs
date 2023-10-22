using System;

namespace OrderManager.API.Controllers.v1.Models;

public record AddOrderItemResponse
{
    public Guid OrderItemId { get; init; }
}
