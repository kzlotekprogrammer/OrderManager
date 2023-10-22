using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;
using OrderManager.Core.Extensions;

namespace OrderManager.Core.Commands.CustomerCommands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CommandResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(
        IUnitOfWork unitOfWork,
        ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<CommandResult<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        CustomerId customerId = CustomerId.New();
        Customer customer = new Customer(customerId, request.FirstName, request.LastName, request.Address.Map());

        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Guid>.Success(customer.Id.Value);
    }
}
