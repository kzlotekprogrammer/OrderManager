using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.Core.Commands.WarehouseCommands;

public class AddProductCommand : IRequest<CommandResult<Guid>>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Amount { get; private set; }
}
