using University.Core.Enum;

namespace University.Core.Exceptions;

internal sealed class DomainConflictException : Exception
{
    public DomainConflictException(ConflictType conflictType, string message)
        : base(message)
    {
        ConflictType = conflictType;
    }

    public ConflictType ConflictType { get; }
}