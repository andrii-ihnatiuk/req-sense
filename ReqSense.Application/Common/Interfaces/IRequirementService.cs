using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.DTOs.Requirement.Response;

namespace ReqSense.Application.Common.Interfaces;

public interface IRequirementService
{
    Task<IEnumerable<RequirementBriefDto>> GetProjectRequirementsAsync(long projectId);

    Task<RequirementFullDto> GetRequirementByIdAsync(long requirementId);

    Task<long> CreateRequirementAsync(CreateRequirementDto dto, long projectId);

    Task UpdateRequirementAsync(UpdateRequirementDto dto);

    Task DeleteRequirementAsync(long requirementId);
}