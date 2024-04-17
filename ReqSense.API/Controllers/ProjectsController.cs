using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProjectsByUser([FromQuery] string userId, [FromQuery] string filter)
    {
        var projects = await _projectService.GetUserProjectsAsync(userId, filter);
        return Ok(projects);
    }

    [Authorize]
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetProjectById([FromRoute] long id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return Ok(project);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
    {
        var id = await _projectService.CreateProjectAsync(projectDto);
        return CreatedAtAction(nameof(GetProjectById), new { id }, new { id });
    }
}