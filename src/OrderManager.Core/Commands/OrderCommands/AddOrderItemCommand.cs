using System;
using MediatR;
using OrderManager.BuildingBlocks;

namespace OrderManager.Core.Commands.OrderCommands;

public record AddOrderItemCommand : IRequest<CommandResult<Guid>>
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}