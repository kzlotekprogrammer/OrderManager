using System;
using System.Linq.Expressions;

namespace OrderManager.BuildingBlocks.Interfaces;

public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>> ToExpression();
}