using MediatR;

namespace ReqSense.Application.Features.Requirements.Commands.Update;

public record UpdateRequirementCommand(
    long Id,
    string Title,
    string Description) : IRequest<Result>;