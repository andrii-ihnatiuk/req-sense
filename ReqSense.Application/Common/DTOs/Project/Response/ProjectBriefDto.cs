namespace ReqSense.Application.Common.DTOs.Project.Response;

public record ProjectBriefDto(
    long Id,
    string Title,
    string? Description);