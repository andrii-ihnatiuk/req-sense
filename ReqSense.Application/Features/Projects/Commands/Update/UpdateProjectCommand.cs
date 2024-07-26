using MediatR;

namespace ReqSense.Application.Features.Projects.Commands.Update;

public record UpdateProjectCommand(
    long Id,
    string Title,
    string? Description) : IRequest<Result>;