using MediatR;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.Application.Features.Projects.Commands.Delete;

public class DeleteProjectHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteProjectCommand, Result>
{
    public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects.FindAsync([request.ProjectId], cancellationToken);
        if (project is null)
        {
            return Result.Fail(ProjectErrors.NotFound(request.ProjectId));
        }

        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}