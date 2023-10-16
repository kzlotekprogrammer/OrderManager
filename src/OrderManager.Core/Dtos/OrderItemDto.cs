namespace OrderManager.Core.Dtos;

public record OrderItemDto
{
    public string ProductName { get; init; } = default!;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}
