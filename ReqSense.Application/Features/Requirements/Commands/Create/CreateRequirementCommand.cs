using MediatR;

namespace ReqSense.Application.Features.Requirements.Commands.Create;

public record CreateRequirementCommand(
    string Title,
    string Description,
    long ProjectId) : IRequest<Result<long>>;