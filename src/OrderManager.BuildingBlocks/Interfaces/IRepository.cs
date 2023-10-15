using System.Collections.Generic;

namespace OrderManager.BuildingBlocks.Interfaces;

public interface IRepository<TEntity, TIdentifier>
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(ISpecification<TEntity> specification);
    TEntity FindOne(ISpecification<TEntity> specification);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}