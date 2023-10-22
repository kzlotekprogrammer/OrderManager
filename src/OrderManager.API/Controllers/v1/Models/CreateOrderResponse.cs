using System;

namespace OrderManager.API.Controllers.v1.Models;

public record CreateOrderResponse
{
    public Guid OrderId { get; init; }
}
