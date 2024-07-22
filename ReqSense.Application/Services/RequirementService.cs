using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.DTOs.Requirement.Response;
using ReqSense.Application.Common.Errors;
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

    public async Task<Result<RequirementFullDto>> GetRequirementByIdAsync(long requirementId)
    {
        var requirement = await dbContext.Requirements
            .Include(e => e.Creator)
            .Include(e => e.LastEditor)
            .FirstOrDefaultAsync(e => e.Id.Equals(requirementId));

        if (requirement is null)
        {
            return Result.Fail<RequirementFullDto>(RequirementErrors.NotFound(requirementId));
        }

        return Result.Ok(mapper.Map<RequirementFullDto>(requirement));
    }

    public async Task<Result<long>> CreateRequirementAsync(CreateRequirementDto dto, long projectId)
    {
        var existingRequirement = await dbContext.Requirements.FirstOrDefaultAsync(p =>
            p.Title.Equals(dto.Title) && p.ProjectId.Equals(projectId));
        if (existingRequirement is not null)
        {
            return Result.Fail<long>(RequirementErrors.DuplicateTitle(dto.Title));
        }

        var requirement = mapper.Map<Requirement>(dto);
        requirement.ProjectId = projectId;

        dbContext.Requirements.Add(requirement);
        await dbContext.SaveChangesAsync();
        return Result.Ok(requirement.Id);
    }

    public async Task<Result> UpdateRequirementAsync(UpdateRequirementDto dto)
    {
        var requirement = await dbContext.Requirements.FindAsync(dto.Id);
        if (requirement is null)
        {
            return Result.Fail(RequirementErrors.NotFound(dto.Id));
        }

        mapper.Map(dto, requirement);
        await dbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteRequirementAsync(long requirementId)
    {
        var requirement = await dbContext.Requirements.FindAsync(requirementId);
        if (requirement is null)
        {
            return Result.Fail(RequirementErrors.NotFound(requirementId));
        }

        dbContext.Requirements.Remove(requirement!);
        await dbContext.SaveChangesAsync();
        return Result.Ok();
    }
}