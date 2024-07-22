namespace ReqSense.Application.Common.Errors.Base;

public record InvalidCredentialsError(string Code, string Message) : Error(Code, Message);