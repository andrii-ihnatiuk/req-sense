using ReqSense.Domain.Common;

namespace ReqSense.Application.Common.Extensions;

public static class ResultExtensions
{
    public static TOutcome MatchToError<TOutcome>(this Result result,
        Dictionary<string, Func<Error, TOutcome>> handlers)
    {
        if (result.IsSuccess)
        {
            throw new ArgumentException("The result is not in failed state");
        }

        if (handlers.TryGetValue(result.Error.Code, out var callback))
        {
            return callback.Invoke(result.Error);
        }

        throw new ArgumentOutOfRangeException(nameof(result), "No handler function for given error code was provided");
    }
}