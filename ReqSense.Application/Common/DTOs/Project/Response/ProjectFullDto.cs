namespace ReqSense.Application.Common.DTOs.Project.Response;

public record ProjectFullDto(
    long Id,
    string Title,
    string? Description);