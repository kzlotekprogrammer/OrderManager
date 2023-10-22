using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public record Address
{
    [Required]
    [StringLength(100)]
    public string City { get; init; } = default!;
    [StringLength(100)]
    public string? Street { get; init; }
    [StringLength(6)]
    public string? PostalCode { get; init; }
    [StringLength(100)]
    public string? PostOffice { get; init; }
}
