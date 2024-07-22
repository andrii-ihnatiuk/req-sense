using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
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
        return requirement.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpPost]
    [Route("/projects/{projectId:long}/requirements")]
    public async Task<IActionResult> CreateRequirement([FromRoute] long projectId, [FromBody] CreateRequirementDto dto)
    {
        var result = await requirementService.CreateRequirementAsync(dto, projectId);
        return result.Match(
            onSuccess: id => Ok(new { id }),
            onFail: this.FromError);
    }

    [HttpPut("{requirementId:long}")]
    public async Task<IActionResult> UpdateRequirement([FromBody] UpdateRequirementDto dto)
    {
        var updateResult = await requirementService.UpdateRequirementAsync(dto);
        return updateResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }

    [HttpDelete("{requirementId:long}")]
    public async Task<IActionResult> DeleteRequirement([FromRoute] long requirementId)
    {
        var deleteResult = await requirementService.DeleteRequirementAsync(requirementId);
        return deleteResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }
}