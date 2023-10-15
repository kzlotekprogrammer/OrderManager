namespace OrderManager.Core.Dtos;

public record OrderItemDto
{
    public string ProductName { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}
