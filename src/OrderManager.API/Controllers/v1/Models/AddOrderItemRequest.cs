using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public record AddOrderItemRequest
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    [Range(0, int.MaxValue)]
    public int Quantity { get; init; }
}
