using System;
using Microsoft.EntityFrameworkCore.Storage;
using OrderManager.BuildingBlocks.Interfaces;

namespace OrderManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _transaction!.Commit();
        _transaction = null;
    }

    public void RollbackTransaction()
    {
        _transaction!.Rollback();
        _transaction = null;
    }
}