using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.BuildingBlocks.Specifications;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;
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
        try
        {
            _unitOfWork.BeginTransaction();

            CustomerId customerId = new(request.CustomerId);
            Customer? customer = await _customerRepository.FindOneAsync(new GetEntityByIdSpecification<Customer, CustomerId>(customerId));

            if (customer is null)
                return CommandResult<Guid>.Failure($"Customer with id={request.CustomerId} does not exists");

            OrderId orderId = OrderId.New();
            Order order = new(orderId, customerId, customer.Address);

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