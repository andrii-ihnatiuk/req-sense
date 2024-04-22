namespace ReqSense.Application.Common.DTOs.Project.Response;

public record ProjectInsightsDto(
    int RequirementsByWeek,
    int TotalRequirements);