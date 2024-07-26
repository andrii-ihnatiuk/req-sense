using AutoMapper;
using MediatR;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Application.Features.Projects.DTOs;

namespace ReqSense.Application.Features.Projects.Queries.GetById;

public class GetProjectByIdHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetProjectByIdQuery, Result<ProjectFullDto>>
{
    public async Task<Result<ProjectFullDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects.FindAsync([request.ProjectId], cancellationToken);
        if (project is null)
        {
            return Result.Fail<ProjectFullDto>(ProjectErrors.NotFound(request.ProjectId));
        }

        return Result.Ok(mapper.Map<ProjectFullDto>(project));
    }
}