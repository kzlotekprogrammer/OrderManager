using System;
using MediatR;
using OrderManager.BuildingBlocks;

namespace OrderManager.Core.Commands.OrderCommands;

public record CreateOrderCommand : IRequest<CommandResult<Guid>>
{
    public Guid CustomerId;
}