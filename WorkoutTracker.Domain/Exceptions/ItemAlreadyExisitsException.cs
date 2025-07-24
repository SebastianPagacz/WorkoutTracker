namespace WorkoutTracker.Domain.Exceptions;

public class ItemAlreadyExisitsException : Exception
{
    public ItemAlreadyExisitsException() : base() { }
    public ItemAlreadyExisitsException(string message) : base(message) { }
    public ItemAlreadyExisitsException(string message, Exception innerException) : base(message, innerException) { }
}
