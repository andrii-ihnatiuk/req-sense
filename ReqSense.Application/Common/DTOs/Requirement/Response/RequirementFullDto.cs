namespace ReqSense.Application.Common.DTOs.Requirement.Response;

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