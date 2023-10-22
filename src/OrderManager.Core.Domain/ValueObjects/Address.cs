namespace OrderManager.Core.Domain.ValueObjects;

public record Address
{
    public string City { get; init; } = default!;
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
    public string? PostalOffice { get; init; }
}