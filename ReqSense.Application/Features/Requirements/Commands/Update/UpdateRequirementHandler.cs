using AutoMapper;
using MediatR;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.Application.Features.Requirements.Commands.Update;

public class UpdateRequirementHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<UpdateRequirementCommand, Result>
{
    public async Task<Result> Handle(UpdateRequirementCommand request, CancellationToken cancellationToken)
    {
        var requirement = await dbContext.Requirements.FindAsync([request.Id], cancellationToken);
        if (requirement is null)
        {
            return Result.Fail(RequirementErrors.NotFound(request.Id));
        }

        mapper.Map(request, requirement);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}