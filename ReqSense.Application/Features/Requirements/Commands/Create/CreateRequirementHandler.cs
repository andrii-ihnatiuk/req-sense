using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Features.Requirements.Commands.Create;

public class CreateRequirementHandler(
    IApplicationDbContext dbContext,
    IMapper mapper): IRequestHandler<CreateRequirementCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateRequirementCommand request, CancellationToken cancellationToken)
    {
        var existingRequirement = await dbContext.Requirements.FirstOrDefaultAsync(p =>
            p.Title.Equals(request.Title) && p.ProjectId.Equals(request.ProjectId),
            cancellationToken: cancellationToken);
        if (existingRequirement is not null)
        {
            return Result.Fail<long>(RequirementErrors.DuplicateTitle(request.Title));
        }

        var requirement = mapper.Map<Requirement>(request);

        dbContext.Requirements.Add(requirement);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok(requirement.Id);
    }
}