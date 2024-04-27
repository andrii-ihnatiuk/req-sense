namespace ReqSense.Application.Common.DTOs.Requirement.Response;

public record RequirementBriefDto(
    long Id,
    string Title,
    string Status,
    DateTimeOffset Created,
    string CreatorName
);