using System.ComponentModel.DataAnnotations;

namespace OrderManager.API.Controllers.v1.Models;

public class CreateCustomerRequest
{
    [StringLength(100)]
    public string FirstName { get; init; } = default!;
    [StringLength(100)]
    public string LastName { get; init; } = default!;
    [Required]
    public Address Address { get; init; } = default!;
}
