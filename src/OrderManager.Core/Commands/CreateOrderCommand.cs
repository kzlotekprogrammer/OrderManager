using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;

namespace OrderManager.Core.Commands;

public record CreateOrderCommand : IRequest<CommandResult<Guid>>
{
    public Guid CustomerId;
}