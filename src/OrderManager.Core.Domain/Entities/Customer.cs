using OrderManager.BuildingBlocks;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.ValueObjects;

namespace OrderManager.Core.Domain.Entities;

public class Customer : AggregateRoot<CustomerId>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public Address Address { get; private set; } = default!;

    private Customer()
    {

    }

    public Customer(CustomerId id, string firstName, string lastName, Address address) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public void UpdateDetails(string firstName, string lastName, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}
