namespace ReqSense.Application.Common.Exceptions;

public class GeminiException(string message) : Exception(message)
{
    public static void ThrowIfNull(object? obj, string message)
    {
        if (obj is null)
        {
            throw new GeminiException(message);
        }
    }

    public static void ThrowIfFalse(bool condition, string message)
    {
        if (!condition)
        {
            throw new GeminiException(message);
        }
    }
}