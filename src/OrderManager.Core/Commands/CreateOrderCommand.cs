using System;
using System.Collections.Generic;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Dtos;

namespace OrderManager.Core.Commands;

public record CreateOrderCommand : IRequest<CommandResult<Guid>>
{
    public Guid CustomerId;
    public List<OrderItemDto> OrderItems { get; init; } = default!;
}