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

namespace OrderManager.Core.Commands.OrderCommands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    public CreateOrderCommandHandler(
        IUnitOfWork unitOfWork,
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<CommandResult<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        CustomerId customerId = new(request.CustomerId);
        Customer? customer = await _customerRepository.FindOneAsync(new GetEntityByIdSpecification<Customer, CustomerId>(customerId));
        if (customer is null)
            return CommandResult<Guid>.Failure($"Customer with id={request.CustomerId} does not exists");

        OrderId orderId = OrderId.New();
        Order order = new(orderId, customerId, customer.Address);

        await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Guid>.Success(order.Id.Value);
    }
}