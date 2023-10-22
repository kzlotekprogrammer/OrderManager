using System;

namespace OrderManager.API.Controllers.v1.Models;

public record CreateOrderRequest
{
    public Guid CustomerId { get; init; }
}
