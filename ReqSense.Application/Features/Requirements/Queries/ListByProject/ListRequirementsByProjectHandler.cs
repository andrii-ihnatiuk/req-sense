using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.Requirements.DTOs;

namespace ReqSense.Application.Features.Requirements.Queries.ListByProject;

public class ListRequirementsByProjectHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<ListRequirementsByProjectQuery, IEnumerable<RequirementBriefDto>>
{
    public async Task<IEnumerable<RequirementBriefDto>> Handle(ListRequirementsByProjectQuery request,
        CancellationToken cancellationToken)
    {
        var requirements = await dbContext.Requirements
            .Where(e => e.ProjectId.Equals(request.ProjectId))
            .Include(e => e.Creator)
            .OrderByDescending(q => q.Created)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<RequirementBriefDto>>(requirements);
    }
}