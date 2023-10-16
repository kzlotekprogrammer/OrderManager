using System.Collections.Generic;
using OrderManager.BuildingBlocks.Interfaces;

namespace OrderManager.BuildingBlocks.BaseClasses;

public abstract class AggregateRoot<TIdentifier> : Entity<TIdentifier>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AggregateRoot()
    {

    }

    protected AggregateRoot(TIdentifier id) : base(id)
    {
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}