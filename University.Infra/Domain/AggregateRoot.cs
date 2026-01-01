namespace University.Infra.Domain;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : struct, IComparable, IComparable<TId>, IEquatable<TId>, IFormattable
{
}