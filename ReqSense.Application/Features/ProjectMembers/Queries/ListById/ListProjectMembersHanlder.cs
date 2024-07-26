using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.ProjectMembers.DTOs;

namespace ReqSense.Application.Features.ProjectMembers.Queries.ListById;

public class ListProjectMembersHanlder(
    IApplicationDbContext dbContext) : IRequestHandler<ListProjectMembersQuery, IEnumerable<ProjectMemberDto>>
{
    public async Task<IEnumerable<ProjectMemberDto>> Handle(ListProjectMembersQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.ProjectMembers> membersQuery = dbContext.ProjectsMembers
            .Where(q => q.ProjectId.Equals(request.ProjectId))
            .OrderByDescending(q => q.JoinedDate);

        if (request.Limit is not null)
        {
            membersQuery = membersQuery.Take((int)request.Limit);
        }

        var members = await membersQuery
            .Include(q => q.Member)
            .Select(q => new ProjectMemberDto(q.Member.UserName!, q.Member.Email!, q.Role, q.JoinedDate))
            .ToListAsync(cancellationToken);

        return members;
    }
}