using System;

namespace OrderManager.BuildingBlocks.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}