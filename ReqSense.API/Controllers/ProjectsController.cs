using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        var project = await _projectService.GetProjectAsync(id);
        return Ok(project);
    }

    [HttpGet("{id:long}/insights")]
    public async Task<IActionResult> GetProjectInsights([FromRoute] long id)
    {
        var insights = await _projectService.GetProjectInsightsAsync(id);
        return Ok(insights);
    }

    [HttpGet("{id:long}/members")]
    public async Task<IActionResult> GetProjectMembers([FromRoute] long id, [FromQuery] int? limit)
    {
        var members = await _projectService.GetProjectMembersAsync(id, limit);
        return Ok(members);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
    {
        var id = await _projectService.CreateProjectAsync(projectDto);
        return CreatedAtAction(nameof(GetProjectById), new { id }, new { id });
    }
}