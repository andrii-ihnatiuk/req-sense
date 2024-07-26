using MediatR;

namespace ReqSense.Application.Features.Projects.Commands.Delete;

public record DeleteProjectCommand(long ProjectId) : IRequest<Result>;