using MediatR;
using ReqSense.Application.Features.Requirements.DTOs;

namespace ReqSense.Application.Features.Requirements.Queries.GetById;

public record GetRequirementByIdQuery(long RequirementId) : IRequest<Result<RequirementFullDto>>;