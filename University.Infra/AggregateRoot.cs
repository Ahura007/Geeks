namespace University.Infra;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : struct, IComparable, IComparable<TId>, IEquatable<TId>, IFormattable 
{
}