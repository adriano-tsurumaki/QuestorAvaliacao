using System;

namespace Domain.Exceptions;

public class FluentValidationException : Exception
{
    public FluentValidationException() : base() { }

    public FluentValidationException(string message) : base(message) { }

    public FluentValidationException(string message, Exception innerException) : base(message, innerException) { }
}
