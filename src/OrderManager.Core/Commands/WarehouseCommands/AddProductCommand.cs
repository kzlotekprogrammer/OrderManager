using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.Core.Commands.WarehouseCommands;

public record AddProductCommand : IRequest<CommandResult<Guid>>
{
    public string Name { get; init; } = default!;
    public decimal Price { get; init; }
    public int Amount { get; init; }
}
