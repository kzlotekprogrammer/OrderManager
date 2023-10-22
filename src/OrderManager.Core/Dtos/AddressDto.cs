namespace OrderManager.Core.Dtos;

public record AddressDto
{
    public string City { get; init; } = default!;
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
    public string? PostOffice { get; init; }
}
