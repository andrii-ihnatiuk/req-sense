namespace ReqSense.Domain.Common;

public partial class Result(Error error)
{
    public Result() : this(Error.None)
    {
    }

    public bool IsSuccess { get; } = error == Error.None;

    public bool IsFailure => !IsSuccess;

    public Error Error { get; } = error;

    public TOutcome Match<TOutcome>(Func<TOutcome> onSuccess, Func<Error, TOutcome> onFail)
    {
        return IsSuccess ? onSuccess.Invoke() : onFail.Invoke(Error);
    }
}

public partial class Result
{
    public static Result Ok() => new Result();

    public static Result Fail(Error error) => new Result(error);

    public static Result<TValue> Ok<TValue>(TValue value) => new(value);

    public static Result<TValue> Fail<TValue>(Error error) => new(error);
}

public class Result<TValue> : Result
{
    public Result(TValue value)
    {
        Value = value;
    }

    public Result(Error error)
        : base(error)
    {
        Value = default;
    }

    public TValue? Value { get; }

    public TOutcome Match<TOutcome>(Func<TValue, TOutcome> onSuccess, Func<Error, TOutcome> onFail)
    {
        return IsSuccess ? onSuccess.Invoke(Value!) : onFail.Invoke(Error);
    }
}