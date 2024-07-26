namespace ReqSense.Application.Features.Projects.DTOs;

public record ProjectFullDto(
    long Id,
    string Title,
    string? Description);