using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;
using OrderManager.Core.Domain.Interfaces;

namespace OrderManager.Infrastructure.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse, WarehouseId>, IWarehouseRepository
{
    public WarehouseRepository(AppDbContext context) : base(context)
    {

    }

    public override async Task<List<Warehouse>> GetAllAsync()
    {
        return await _context.Warehouses
            .Include(w => w.Products)
            .ToListAsync();
    }

    public override async Task<List<Warehouse>> FindAsync(ISpecification<Warehouse> specification)
    {
        return await _context.Warehouses
            .Where(specification.ToExpression())
            .Include(w => w.Products)
            .ToListAsync();
    }

    public override async Task<Warehouse?> FindOneAsync(ISpecification<Warehouse> specification)
    {
        return await _context.Warehouses
            .Include(w => w.Products)
            .FirstOrDefaultAsync(specification.ToExpression());
    }
}