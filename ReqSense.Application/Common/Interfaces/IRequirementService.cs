using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.DTOs.Requirement.Response;

namespace ReqSense.Application.Common.Interfaces;

public interface IRequirementService
{
    Task<IEnumerable<RequirementBriefDto>> GetProjectRequirementsAsync(long projectId);

    Task<Result<RequirementFullDto>> GetRequirementByIdAsync(long requirementId);

    Task<Result<long>> CreateRequirementAsync(CreateRequirementDto dto, long projectId);

    Task<Result> UpdateRequirementAsync(UpdateRequirementDto dto);

    Task<Result> DeleteRequirementAsync(long requirementId);
}