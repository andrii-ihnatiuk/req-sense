using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
using ReqSense.Application.Features.Projects.Commands.Create;
using ReqSense.Application.Features.Projects.Commands.Delete;
using ReqSense.Application.Features.Projects.Commands.Update;
using ReqSense.Application.Features.Projects.Queries.GetById;
using ReqSense.Application.Features.Projects.Queries.GetInsights;
using ReqSense.Application.Features.Projects.Queries.ListByUser;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProjectsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProjectsByUser([FromQuery] string userId, [FromQuery] string filter)
    {
        var projects = await sender.Send(new ListProjectsByUserQuery(userId, filter));
        return Ok(projects);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetProjectById([FromRoute] long id)
    {
        var projectResult = await sender.Send(new GetProjectByIdQuery(id));
        return projectResult.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpGet("{id:long}/insights")]
    public async Task<IActionResult> GetProjectInsights([FromRoute] long id)
    {
        var insights = await sender.Send(new GetProjectInsightsQuery(id));
        return Ok(insights);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {
        var result = await sender.Send(command);
        return result.Match(
            onSuccess: id => CreatedAtAction(nameof(GetProjectById), new { id }, new { id }),
            onFail: this.FromError);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
    {
        var updateResult = await sender.Send(command);
        return updateResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteProject([FromRoute] long id)
    {
        var deleteResult = await sender.Send(new DeleteProjectCommand(id));
        return deleteResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }
}