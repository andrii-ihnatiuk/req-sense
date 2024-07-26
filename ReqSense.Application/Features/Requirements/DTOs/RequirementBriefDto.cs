namespace ReqSense.Application.Features.Requirements.DTOs;

public record RequirementBriefDto(
    long Id,
    string Title,
    string Status,
    DateTimeOffset Created,
    string CreatorName
);