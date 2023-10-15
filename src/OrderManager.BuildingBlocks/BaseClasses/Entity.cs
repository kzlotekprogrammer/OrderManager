namespace OrderManager.BuildingBlocks.BaseClasses;

public abstract class Entity<TIdentifier>
{
    public TIdentifier Id { get; private set; }

    protected Entity(TIdentifier id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj is not Entity<TIdentifier> otherEntity)
            return false;

        return Id.Equals(otherEntity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TIdentifier> left, Entity<TIdentifier> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TIdentifier> left, Entity<TIdentifier> right)
    {
        return !Equals(left, right);
    }
}