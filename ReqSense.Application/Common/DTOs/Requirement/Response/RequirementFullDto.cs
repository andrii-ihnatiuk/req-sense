namespace ReqSense.Application.Common.DTOs.Requirement.Response;

public record RequirementFullDto(
    long Id,
    string Title,
    string Status,
    DateTimeOffset Created,
    string CreatorName,
    DateTimeOffset? LastModified,
    string? LastEditorName
);