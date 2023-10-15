using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Core.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer, CustomerId>
{
}