using System;
using MediatR;
using OrderManager.BuildingBlocks;
using OrderManager.Core.Dtos;

namespace OrderManager.Core.Commands.CustomerCommands;

public record UpdateDetailsCommand : IRequest<CommandResult<Unit>>
{
    public Guid CustomerId { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public AddressDto Address { get; init; } = default!;
}
