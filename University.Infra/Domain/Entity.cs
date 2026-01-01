namespace University.Infra.Domain;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : struct, IComparable, IComparable<TId>, IEquatable<TId>, IFormattable
{
    public TId Id { get; protected set; }

    public bool Equals(Entity<TId>? other)
    {
        return other != null && Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Equals(entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}