using System;

namespace OrderManager.API.Controllers.v1.Models;

public record UpdatePriceRequest
{
    public Guid ProductId { get; init; }
    public decimal Price { get; init; }
}
