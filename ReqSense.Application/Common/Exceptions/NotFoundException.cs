namespace ReqSense.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }

    public static void ThrowIfNull(object? e, string message)
    {
        if (e is null)
        {
            throw new NotFoundException(message);
        }
    }
}