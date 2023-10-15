using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Core.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order, OrderId>
{
}