using System;
using MediatR;
using OrderManager.BuildingBlocks;

namespace OrderManager.Core.Commands.WarehouseCommands;

public record UpdatePriceCommand : IRequest<CommandResult<Unit>>
{
    public Guid ProductId { get; init; }
    public decimal Price{ get; init; }
}
