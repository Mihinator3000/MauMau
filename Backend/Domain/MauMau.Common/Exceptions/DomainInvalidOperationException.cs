namespace MauMau.Common.Exceptions;

public class DomainInvalidOperationException : Exception
{
    public DomainInvalidOperationException(string? message) : base(message) { }
}