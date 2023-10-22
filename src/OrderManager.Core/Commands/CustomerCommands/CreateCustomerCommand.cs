﻿using System;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Dtos;

namespace OrderManager.Core.Commands.CustomerCommands;

public record CreateCustomerCommand : IRequest<CommandResult<Guid>>
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public AddressDto Address { get; private set; } = default!;
}
