using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Infrastructure.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse, WarehouseId>, IWarehouseRepository
{
    public WarehouseRepository(AppDbContext context) : base(context)
    {

    }
}