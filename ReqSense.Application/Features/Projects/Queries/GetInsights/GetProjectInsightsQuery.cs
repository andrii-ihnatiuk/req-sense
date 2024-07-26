using MediatR;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.Projects.Queries.GetInsights;

public record GetProjectInsightsQuery(long ProjectId) : IRequest<ProjectInsightsDto>;