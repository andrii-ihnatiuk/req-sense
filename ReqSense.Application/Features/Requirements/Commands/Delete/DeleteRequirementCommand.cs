using MediatR;

namespace ReqSense.Application.Features.Requirements.Commands.Delete;

public record DeleteRequirementCommand(long RequirementId) : IRequest<Result>;