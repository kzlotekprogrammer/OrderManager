using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public class UpdateAmountRequest
{
    public Guid ProductId { get; init; }
    [Range(0, int.MaxValue)]
    public int Amount { get; init; }
}
