using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order, OrderId>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {

    }
}