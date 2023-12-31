﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderManager.BuildingBlocks;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.BuildingBlocks.Specifications;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Events;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Core.Commands.WarehouseCommands;

public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, CommandResult<Unit>>
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseRepository _warehouseRepository;

    public UpdatePriceCommandHandler(
        IMediator mediator,
        IUnitOfWork unitOfWork,
        IWarehouseRepository warehouseRepository)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<CommandResult<Unit>> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        Warehouse? warehouse = await _warehouseRepository.FindOneAsync(new GetEntityByIdSpecification<Warehouse, WarehouseId>(WarehouseId.Create()));
        if (warehouse is null)
            return CommandResult<Unit>.Failure($"Warehouse does not exists");

        ProductId productId = new(request.ProductId);
        warehouse.UpdatePrice(productId, request.Price);

        await _warehouseRepository.UpdateAsync(warehouse);

        await _mediator.Publish(new ProductPriceChangedEvent
        {
            ProductId = productId,
            NewPrice = request.Price,
        });

        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Unit>.Success(Unit.Value);
    }
}
