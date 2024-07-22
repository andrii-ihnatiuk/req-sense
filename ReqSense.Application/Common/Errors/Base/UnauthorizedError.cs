namespace ReqSense.Application.Common.Errors.Base;

public record UnauthorizedError(string Code, string Message) : Error(Code, Message);