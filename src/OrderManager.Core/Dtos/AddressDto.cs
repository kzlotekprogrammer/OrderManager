namespace OrderManager.Core.Dtos;

public record AddressDto
{
    public string City { get; init; } = default!;
    public string? Street { get; init; }
    public string? State { get; init; }
    public string? ZipCode { get; init; }
}
