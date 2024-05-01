namespace ReqSense.Application.Common.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
    public static void ThrowIfNull(object? e, string message)
    {
        if (e is null)
        {
            throw new NotFoundException(message);
        }
    }
}