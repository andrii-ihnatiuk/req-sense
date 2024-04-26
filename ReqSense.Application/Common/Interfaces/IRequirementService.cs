using ReqSense.Application.Common.DTOs.Requirement.Request;

namespace ReqSense.Application.Common.Interfaces;

public interface IRequirementService
{
    Task<long> CreateRequirementAsync(CreateRequirementDto dto, long projectId);
}