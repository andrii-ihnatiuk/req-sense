using MediatR;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.Projects.Queries.GetById;

public record GetProjectByIdQuery(long ProjectId) : IRequest<Result<ProjectFullDto>>;