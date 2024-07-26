using MediatR;
using ReqSense.Application.Features.ProjectMembers.DTOs;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.ProjectMembers.Queries.ListById;

public record ListProjectMembersQuery(long ProjectId, int? Limit) : IRequest<IEnumerable<ProjectMemberDto>>;