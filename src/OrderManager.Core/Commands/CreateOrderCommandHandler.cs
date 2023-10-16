using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Interfaces;
using OrderManager.Core.Extensions;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Identifiers;
using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManager.Core.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<CommandResult<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            OrderId orderId = OrderId.New();
            Order order = new(orderId, new CustomerId(request.CustomerId), request.OrderItems.Select(orderItem => orderItem.Map(orderId)).ToList());

            await _orderRepository.AddAsync(order);

            _unitOfWork.CommitTransaction();

            return CommandResult<Guid>.Success(order.Id.Value);

        }
        catch (Exception ex)
        {
            _unitOfWork.RollbackTransaction();
            ExceptionDispatchInfo.Capture(ex).Throw();
            throw;
        }
    }
}