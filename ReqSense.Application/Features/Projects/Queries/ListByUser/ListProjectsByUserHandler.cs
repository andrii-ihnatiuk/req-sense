using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.Projects.DTOs;
using ReqSense.Domain.Constants;

namespace ReqSense.Application.Features.Projects.Queries.ListByUser;

public class ListProjectsByUserHandler(
    IApplicationDbContext dbContext) : IRequestHandler<ListProjectsByUserQuery, IEnumerable<ProjectListItemDto>>
{
    public async Task<IEnumerable<ProjectListItemDto>> Handle(ListProjectsByUserQuery request, CancellationToken cancellationToken)
    {
        var projectsQueryable = dbContext.Projects.AsQueryable();
        projectsQueryable = request.Filter switch
        {
            UserProjectsFilter.Own => projectsQueryable.Where(p =>
                p.Members.Any(m => m.MemberId.Equals(request.UserId) && m.Role.Equals(Roles.Owner))),
            UserProjectsFilter.MemberIn => projectsQueryable.Where(p =>
                p.Members.Any(m => m.MemberId.Equals(request.UserId) && m.Role.Equals(Roles.Member))),
            _ => projectsQueryable.Where(e => e.Members.Any(m => m.MemberId.Equals(request.UserId)))
        };

        var projects = await projectsQueryable.Select(p => new ProjectListItemDto(
                p.Id,
                p.Title,
                p.Description,
                p.Members.Single(m => m.Role.Equals(Roles.Owner)).Member.UserName!,
                p.Members.Count))
            .ToListAsync(cancellationToken);

        return projects;
    }
}