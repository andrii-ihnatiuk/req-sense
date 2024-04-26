using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("/projects/{projectId:long}/requirements")]
public class RequirementsController(
    IRequirementService requirementService
) : ControllerBase
{
    [FromRoute]
    public long ProjectId { get; init; }

    [HttpPost]
    public async Task<IActionResult> CreateRequirement([FromBody] CreateRequirementDto dto)
    {
        var id = await requirementService.CreateRequirementAsync(dto, ProjectId);
        return Ok(new { id });
    }
}