using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.Core.Commands.OrderCommands;

public class AddOrderItemCommand : IRequest<CommandResult<Unit>>
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}