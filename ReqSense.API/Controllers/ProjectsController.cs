using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectsByUser([FromQuery] string userId, [FromQuery] string filter)
    {
        var projects = await _projectService.GetUserProjectsAsync(userId, filter);
        return Ok(projects);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetProjectById([FromRoute] long id)
    {
        var projectResult = await _projectService.GetProjectAsync(id);
        return projectResult.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpGet("{id:long}/insights")]
    public async Task<IActionResult> GetProjectInsights([FromRoute] long id)
    {
        var insights = await _projectService.GetProjectInsightsAsync(id);
        return Ok(insights);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto projectDto)
    {
        var result = await _projectService.CreateProjectAsync(projectDto);
        return result.Match(
            onSuccess: id => CreatedAtAction(nameof(GetProjectById), new { id }, new { id }),
            onFail: this.FromError);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto projectDto)
    {
        var updateResult = await _projectService.UpdateProjectAsync(projectDto);
        return updateResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteProject([FromRoute] long id)
    {
        var deleteResult = await _projectService.DeleteProjectAsync(id);
        return deleteResult.Match(onSuccess: NoContent, onFail: this.FromError);
    }
}