using System;
using System.Linq.Expressions;
using OrderManager.BuildingBlocks.BaseClasses;
using OrderManager.BuildingBlocks.Interfaces;

namespace OrderManager.BuildingBlocks.Specifications;

public class GetEntityByIdSpecification<TEntity, TIdentifier> : ISpecification<TEntity> where TEntity : Entity<TIdentifier>
{
    private readonly TIdentifier _id;

    public GetEntityByIdSpecification(TIdentifier id)
    {
        _id = id;
    }

    public Expression<Func<TEntity, bool>> ToExpression()
    {
        return entity => entity.Id != null && entity.Id.Equals(_id);
    }
}