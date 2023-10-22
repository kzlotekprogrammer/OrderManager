using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public record UpdateDetailsRequest
{
    public Guid CustomerId { get; init; }
    [StringLength(20)]
    public string FirstName { get; init; } = default!;
    [StringLength(20)]
    public string LastName { get; init; } = default!;
    [Required]
    public Address Address { get; init; } = default!;
}
