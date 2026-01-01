using University.Infra.Core.Enum;

namespace University.Infra.Core.Exceptions;

public sealed class DomainConflictException : Exception
{
    public DomainConflictException(ConflictType conflictType, string message)
        : base(message)
    {
        ConflictType = conflictType;
    }

    public ConflictType ConflictType { get; }
}