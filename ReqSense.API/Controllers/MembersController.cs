using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Features.ProjectMembers.Queries.ListById;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("/projects/{projectId:long}/members")]
public class MembersController(ISender sender) : ControllerBase
{
    [FromRoute]
    public long ProjectId { get; init; }

    [HttpGet]
    public async Task<IActionResult> GetProjectMembers([FromQuery] int? limit)
    {
        var members = await sender.Send(new ListProjectMembersQuery(ProjectId, limit));
        return Ok(members);
    }
}