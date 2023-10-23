using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderManager.BuildingBlocks;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.BuildingBlocks.Specifications;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Core.Commands.OrderCommands;

public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, CommandResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public AddOrderItemCommandHandler(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        IWarehouseRepository warehouseRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
    }

    public async Task<CommandResult<Guid>> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        Warehouse? warehouse = await _warehouseRepository.FindOneAsync(new GetEntityByIdSpecification<Warehouse, WarehouseId>(WarehouseId.Create()));
        if (warehouse is null)
            return CommandResult<Guid>.Failure($"Warehouse does not exists");

        Product? product = warehouse.Products.FirstOrDefault(p => p.Id.Value == request.ProductId);
        if (product is null)
            return CommandResult<Guid>.Failure($"Product with id={request.ProductId} is not defined in warehouse");

        OrderId orderId = new(request.OrderId);
        Order? order = await _orderRepository.FindOneAsync(new GetEntityByIdSpecification<Order, OrderId>(orderId));
        if (order is null)
            return CommandResult<Guid>.Failure($"Order with id={request.OrderId} does not exists");

        OrderItemId orderItemId = OrderItemId.New();
        OrderItem orderItem = new(orderItemId, orderId, product.Id, product.Name, product.Price, request.Quantity);
        order.AddItem(orderItem);

        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Guid>.Success(orderItemId.Value);
    }
}