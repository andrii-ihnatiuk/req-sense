using AutoMapper;
using MediatR;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.Application.Features.Projects.Commands.Update;

public class UpdateProjectHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<UpdateProjectCommand, Result>
{
    public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects.FindAsync([request.Id], cancellationToken);
        if (project is null)
        {
            return Result.Fail(ProjectErrors.NotFound(request.Id));
        }

        mapper.Map(request, project);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}