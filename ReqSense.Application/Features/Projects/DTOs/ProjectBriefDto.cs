namespace ReqSense.Application.Features.Projects.DTOs;

public record ProjectBriefDto(
    long Id,
    string Title,
    string? Description);