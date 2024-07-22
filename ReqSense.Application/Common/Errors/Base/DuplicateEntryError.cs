namespace ReqSense.Application.Common.Errors.Base;

public record DuplicateEntryError(string Code, string Message) : Error(Code, Message);