using MediatR;

namespace ReqSense.Application.Features.Projects.Commands.Create;

public record CreateProjectCommand(
    string Title,
    string? Description) : IRequest<Result<long>>;