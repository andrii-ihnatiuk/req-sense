using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Features.Projects.Commands.Create;

public class CreateProjectHandler(
    IApplicationDbContext dbContext,
    ICurrentUser currentUser,
    IMapper mapper) : IRequestHandler<CreateProjectCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Id is null)
        {
            return Result.Fail<long>(UserErrors.Unauthorized());
        }

        var existingProject = await dbContext.Projects
            .FirstOrDefaultAsync(p => p.Title.Equals(request.Title), cancellationToken);
        if (existingProject is not null)
        {
            return Result.Fail<long>(ProjectErrors.DuplicateTitle(request.Title));
        }

        var project = mapper.Map<Project>(request);
        project.Members.Add(Domain.Entities.ProjectMembers.Owner(currentUser.Id));
        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok(project.Id);
    }
}