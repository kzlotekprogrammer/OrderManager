using OrderManager.BuildingBlocks.Interfaces;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Core.Domain.Interfaces;

public interface IWarehouseRepository : IRepository<Warehouse, WarehouseId>
{
}