namespace ReqSense.Application.Common.DTOs.Requirement.Request;

public record UpdateRequirementDto(
    long Id,
    string Title,
    string Description
);