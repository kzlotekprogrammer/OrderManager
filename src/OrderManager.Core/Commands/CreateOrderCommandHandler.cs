using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.Core.Domain.Interfaces;
using OrderManager.Core.Extensions;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Identifiers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManager.Core.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult<Guid>>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<CommandResult<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = new(OrderId.New(), request.CustomerId, request.OrderItems.Select(orderItem => orderItem.Map()).ToList());

        await _orderRepository.AddAsync(order);

        return CommandResult<Guid>.Success(order.Id.Value);
    }
}