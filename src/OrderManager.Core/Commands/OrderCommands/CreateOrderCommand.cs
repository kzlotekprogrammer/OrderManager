using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.Core.Commands.OrderCommands;

public record CreateOrderCommand : IRequest<CommandResult<Guid>>
{
    public Guid CustomerId;
}