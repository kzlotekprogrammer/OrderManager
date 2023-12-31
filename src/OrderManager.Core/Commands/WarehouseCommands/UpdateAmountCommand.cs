﻿using System;
using MediatR;
using OrderManager.BuildingBlocks;

namespace OrderManager.Core.Commands.WarehouseCommands;

public record UpdateAmountCommand : IRequest<CommandResult<Unit>>
{
    public Guid ProductId { get; init; }
    public int Amount { get; init; }
}
