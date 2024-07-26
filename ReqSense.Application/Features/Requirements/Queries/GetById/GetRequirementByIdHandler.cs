using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.Requirements.DTOs;

namespace ReqSense.Application.Features.Requirements.Queries.GetById;

public class GetRequirementByIdHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetRequirementByIdQuery, Result<RequirementFullDto>>
{
    public async Task<Result<RequirementFullDto>> Handle(GetRequirementByIdQuery request,
        CancellationToken cancellationToken)
    {
        var requirement = await dbContext.Requirements
            .Include(e => e.Creator)
            .Include(e => e.LastEditor)
            .FirstOrDefaultAsync(e => e.Id.Equals(request.RequirementId), cancellationToken);

        if (requirement is null)
        {
            return Result.Fail<RequirementFullDto>(RequirementErrors.NotFound(request.RequirementId));
        }

        return Result.Ok(mapper.Map<RequirementFullDto>(requirement));
    }
}