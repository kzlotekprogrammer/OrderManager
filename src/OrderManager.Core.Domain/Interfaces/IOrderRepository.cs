using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order, OrderId>
{
    Task<List<Order>> GetOrdersAffectedByProductPriceChangeAsync(ProductId productId);
}