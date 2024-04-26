using AutoMapper;
using ReqSense.Application.Common.DTOs.Requirement.Request;
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
    public async Task<long> CreateRequirementAsync(CreateRequirementDto dto, long projectId)
    {
        var requirement = mapper.Map<Requirement>(dto);
        if (currentUser.Id is null)
        {
            throw new IdentityException("You must sign in to perform this action.");
        }

        requirement.ProjectId = projectId;
        requirement.CreatedBy = currentUser.Id;

        dbContext.Requirements.Add(requirement);
        await dbContext.SaveChangesAsync();
        return requirement.Id;
    }
}