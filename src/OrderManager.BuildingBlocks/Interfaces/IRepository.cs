using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.BuildingBlocks.Interfaces;

public interface IRepository<TEntity, TIdentifier>
{
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> FindAsync(ISpecification<TEntity> specification);
    Task<TEntity?> FindOneAsync(ISpecification<TEntity> specification);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}