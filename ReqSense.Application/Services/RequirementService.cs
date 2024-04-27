using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.DTOs.Requirement.Response;
using ReqSense.Application.Common.Exceptions;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Services;

public class RequirementService(
    IApplicationDbContext dbContext,
    ICurrentUser currentUser,
    IMapper mapper
) : IRequirementService
{
    public async Task<IEnumerable<RequirementBriefDto>> GetProjectRequirementsAsync(long projectId)
    {
        var requirements = await dbContext.Requirements
            .Where(e => e.ProjectId.Equals(projectId))
            .Include(e => e.Creator)
            .OrderByDescending(q => q.Created)
            .ToListAsync();

        return mapper.Map<IEnumerable<RequirementBriefDto>>(requirements);
    }

    public async Task<RequirementFullDto> GetRequirementByIdAsync(long requirementId)
    {
        var requirement = await dbContext.Requirements
            .Include(e => e.Creator)
            .Include(e => e.LastEditor)
            .SingleAsync(e => e.Id.Equals(requirementId));

        return mapper.Map<RequirementFullDto>(requirement);
    }

    public async Task<long> CreateRequirementAsync(CreateRequirementDto dto, long projectId)
    {
        var requirement = mapper.Map<Requirement>(dto);
        requirement.ProjectId = projectId;

        dbContext.Requirements.Add(requirement);
        await dbContext.SaveChangesAsync();
        return requirement.Id;
    }
}