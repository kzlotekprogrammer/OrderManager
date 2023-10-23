using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;
using OrderManager.Domain.Enums;

namespace OrderManager.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order, OrderId>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public override async Task<List<Order>> FindAsync(ISpecification<Order> specification)
    {
        return await _context.Orders
            .Where(specification.ToExpression())
            .Include(o => o.Items)
            .ToListAsync();
    }

    public override async Task<Order?> FindOneAsync(ISpecification<Order> specification)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(specification.ToExpression());
    }

    public async Task<List<Order>> GetOrdersAffectedByProductPriceChangeAsync(ProductId productId)
    {
        List<Order> ordersContainingProduct = await _context.Orders
                .Where(order => order.Status == OrderStatus.Pending &&
                                order.Items.Any(item => item.ProductId == productId))
                .Include(o => o.Items)
                .ToListAsync();

        return ordersContainingProduct;
    }
}