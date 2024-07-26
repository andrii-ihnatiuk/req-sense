using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.Projects.Queries.GetInsights;

public class GetProjectInsightsHandler(IApplicationDbContext dbContext) : IRequestHandler<GetProjectInsightsQuery, ProjectInsightsDto>
{
    public async Task<ProjectInsightsDto> Handle(GetProjectInsightsQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Requirements.Where(q => q.ProjectId.Equals(request.ProjectId));
        var totalRequirements = await query.CountAsync(cancellationToken);
        var requirementsThisWeek = await query
            .Where(q => q.Created >= DateTimeOffset.Now.AddDays(-7))
            .CountAsync(cancellationToken);

        return new ProjectInsightsDto(requirementsThisWeek, totalRequirements);
    }
}