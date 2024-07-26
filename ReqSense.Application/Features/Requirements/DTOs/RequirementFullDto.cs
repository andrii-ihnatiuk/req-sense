namespace ReqSense.Application.Features.Requirements.DTOs;

public record RequirementFullDto(
    long Id,
    string Title,
    string Description,
    string Status,
    DateTimeOffset Created,
    string CreatorName,
    DateTimeOffset? LastModified,
    string? LastEditorName
);