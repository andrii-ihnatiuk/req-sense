namespace ReqSense.Application.Features.Projects.DTOs;

public record ProjectInsightsDto(
    int RequirementsByWeek,
    int TotalRequirements);