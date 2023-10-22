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
using OrderManager.Core.Extensions;

namespace OrderManager.Core.Commands.CustomerCommands;

public class UpdateDetailsCommandHandler : IRequestHandler<UpdateDetailsCommand, CommandResult<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public UpdateDetailsCommandHandler(
        IUnitOfWork unitOfWork,
        ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<CommandResult<Unit>> Handle(UpdateDetailsCommand request, CancellationToken cancellationToken)
    {
        CustomerId customerId = new CustomerId(request.CustomerId);
        Customer? customer = await _customerRepository.FindOneAsync(new GetEntityByIdSpecification<Customer, CustomerId>(customerId));
        if (customer is null)
            return CommandResult<Unit>.Failure($"Customer with id={request.CustomerId} does not exists");

        customer.UpdateDetails(request.FirstName, request.LastName, request.Address.Map());

        await _customerRepository.UpdateAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        return CommandResult<Unit>.Success(Unit.Value);
    }
}
