namespace ReqSense.Application.Common.DTOs.Project.Request;

public record UpdateProjectDto(
    long Id,
    string Title,
    string? Description);