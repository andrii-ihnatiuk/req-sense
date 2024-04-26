using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("/projects/{projectId:long}/members")]
public class MembersController(
    IProjectService projectService
) : ControllerBase
{
    [FromRoute]
    public long ProjectId { get; init; }

    [HttpGet]
    public async Task<IActionResult> GetProjectMembers([FromQuery] int? limit)
    {
        var members = await projectService.GetProjectMembersAsync(ProjectId, limit);
        return Ok(members);
    }
}