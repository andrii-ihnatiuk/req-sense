using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RequirementsController(
    IRequirementService requirementService
) : ControllerBase
{
    [HttpGet]
    [Route("/projects/{projectId:long}/requirements")]
    public async Task<IActionResult> GetProjectRequirements([FromRoute] long projectId)
    {
        var requirements = await requirementService.GetProjectRequirementsAsync(projectId);
        return Ok(requirements);
    }

    [HttpGet("{requirementId:long}")]
    public async Task<IActionResult> GetRequirementById([FromRoute] long requirementId)
    {
        var requirement = await requirementService.GetRequirementByIdAsync(requirementId);
        return Ok(requirement);
    }

    [HttpPost]
    [Route("/projects/{projectId:long}/requirements")]
    public async Task<IActionResult> CreateRequirement([FromRoute] long projectId, [FromBody] CreateRequirementDto dto)
    {
        var id = await requirementService.CreateRequirementAsync(dto, projectId);
        return Ok(new { id });
    }
}