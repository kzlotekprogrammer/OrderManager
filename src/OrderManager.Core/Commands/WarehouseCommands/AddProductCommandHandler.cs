using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.BuildingBlocks.Specifications;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Core.Commands.WarehouseCommands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, CommandResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseRepository _warehouseRepository;

    public AddProductCommandHandler(
        IUnitOfWork unitOfWork,
        IWarehouseRepository warehouseRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<CommandResult<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Warehouse? warehouse = await _warehouseRepository.FindOneAsync(new GetEntityByIdSpecification<Warehouse, WarehouseId>(WarehouseId.Create()));
        if (warehouse is null)
            return CommandResult<Guid>.Failure($"Warehouse does not exists");

        ProductId productId = ProductId.New();
        Product product = new(productId, WarehouseId.Create(), request.Name, request.Price, request.Amount);
        warehouse.AddProduct(product);

        await _warehouseRepository.UpdateAsync(warehouse);
        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Guid>.Success(productId.Value);
    }
}
