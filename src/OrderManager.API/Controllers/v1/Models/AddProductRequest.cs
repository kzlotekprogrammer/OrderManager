using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public record AddProductRequest
{
    [StringLength(100)]
    public string Name { get; init; } = default!;
    [Range(0, int.MaxValue)]
    public decimal Price { get; init; }
    [Range(0, int.MaxValue)]
    public int Amount { get; init; }
}
