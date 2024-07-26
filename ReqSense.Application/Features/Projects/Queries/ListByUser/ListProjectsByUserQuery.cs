using MediatR;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.Projects.Queries.ListByUser;

public record ListProjectsByUserQuery(string UserId, string Filter) : IRequest<IEnumerable<ProjectListItemDto>>;