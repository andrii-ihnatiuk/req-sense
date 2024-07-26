using MediatR;
using ReqSense.Application.Features.Requirements.DTOs;

namespace ReqSense.Application.Features.Requirements.Queries.ListByProject;

public record ListRequirementsByProjectQuery(long ProjectId) : IRequest<IEnumerable<RequirementBriefDto>>;