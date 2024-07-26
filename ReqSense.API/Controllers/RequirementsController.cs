using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
using ReqSense.Application.Features.Requirements.Commands.Create;
using ReqSense.Application.Features.Requirements.Commands.Delete;
using ReqSense.Application.Features.Requirements.Commands.Update;
using ReqSense.Application.Features.Requirements.Queries.GetById;
using ReqSense.Application.Features.Requirements.Queries.ListByProject;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RequirementsController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Route("/projects/{projectId:long}/requirements")]
    public async Task<IActionResult> GetProjectRequirements([FromRoute] long projectId)
    {
        var requirements = await sender.Send(new ListRequirementsByProjectQuery(projectId));
        return Ok(requirements);
    }

    [HttpGet("{requirementId:long}")]
    public async Task<IActionResult> GetRequirementById([FromRoute] long requirementId)
    {
        var requirement = await sender.Send(new GetRequirementByIdQuery(requirementId));
        return requirement.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequirement([FromBody] CreateRequirementCommand command)
    {
        var result = await sender.Send(command);
        return result.Match(
            onSuccess: id => Ok(new { id }),
            onFail: this.FromError);
    }

    [HttpPut("{requirementId:long}")]
    public async Task<IActionResult> UpdateRequirement([FromBody] UpdateRequirementCommand command)
    {
        var updateResult = await sender.Send(command);
        return updateResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }

    [HttpDelete("{requirementId:long}")]
    public async Task<IActionResult> DeleteRequirement([FromRoute] long requirementId)
    {
        var deleteResult = await sender.Send(new DeleteRequirementCommand(requirementId));
        return deleteResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }
}