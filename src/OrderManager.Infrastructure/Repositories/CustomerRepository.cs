using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer, CustomerId>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {

    }
}