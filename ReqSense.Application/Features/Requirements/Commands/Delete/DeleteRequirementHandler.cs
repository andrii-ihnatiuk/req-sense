using MediatR;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.Application.Features.Requirements.Commands.Delete;

public class DeleteRequirementHandler(IApplicationDbContext dbContext)
    : IRequestHandler<DeleteRequirementCommand, Result>
{
    public async Task<Result> Handle(DeleteRequirementCommand request, CancellationToken cancellationToken)
    {
        var requirement = await dbContext.Requirements.FindAsync([request.RequirementId], cancellationToken);
        if (requirement is null)
        {
            return Result.Fail(RequirementErrors.NotFound(request.RequirementId));
        }

        dbContext.Requirements.Remove(requirement!);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}