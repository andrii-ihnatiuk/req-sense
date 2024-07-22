namespace ReqSense.Application.Common.Errors.Base;

public record ValidationError(string Code, string Message) : Error(Code, Message);