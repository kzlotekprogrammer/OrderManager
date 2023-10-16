namespace OrderManager.Core.Domain.ValueObjects;

public record Address
{
    public string City { get; init; } = default!;
    public string? Street { get; init; }
    public string? State { get; init; }
    public string? ZipCode { get; init; }
}