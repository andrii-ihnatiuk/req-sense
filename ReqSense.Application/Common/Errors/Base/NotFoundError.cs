namespace ReqSense.Application.Common.Errors.Base;

public record NotFoundError(string Code, string Message) : Error(Code, Message);