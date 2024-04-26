namespace ReqSense.Application.Common.DTOs.Requirement.Request;

public record CreateRequirementDto(
    string Title,
    string Description
);