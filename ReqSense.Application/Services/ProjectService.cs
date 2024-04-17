using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.DTOs.Project.Response;
using ReqSense.Application.Common.Exceptions;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Constants;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;

    public ProjectService(IApplicationDbContext dbContext, ICurrentUser currentUser, IMapper mapper)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectListItemDto>> GetUserProjectsAsync(string userId, string filter)
    {
        var projectsQueryable = _dbContext.Projects.AsQueryable();
        projectsQueryable = filter switch
        {
            UserProjectsFilter.Own => projectsQueryable.Where(p =>
                p.Members.Any(m => m.MemberId.Equals(userId) && m.Role.Equals(Roles.Owner))),
            UserProjectsFilter.MemberIn => projectsQueryable.Where(p =>
                p.Members.Any(m => m.MemberId.Equals(userId) && m.Role.Equals(Roles.Member))),
            _ => projectsQueryable.Where(e => e.Members.Any(m => m.MemberId.Equals(userId)))
        };

        var projects = await projectsQueryable.Select(p => new ProjectListItemDto(
                p.Id,
                p.Title,
                p.Description,
                p.Members.Single(m => m.Role.Equals(Roles.Owner)).Member.UserName!,
                p.Members.Count))
            .ToListAsync();

        return projects;
    }

    public async Task<ProjectFullDto> GetProjectAsync(long id)
    {
        var project = await _dbContext.Projects.FindAsync(id);
        if (project is null)
        {
            throw new NotFoundException($"Project with id {id} was not found.");
        }

        return _mapper.Map<ProjectFullDto>(project);
    }

    public async Task<long> CreateProjectAsync(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);
        if (_currentUser.Id is null)
        {
            throw new IdentityException("You must sign in to perform this action.");
        }

        project.Members.Add(ProjectMembers.Owner(_currentUser.Id));
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        return project.Id;
    }

    public async Task UpdateProjectAsync(UpdateProjectDto dto)
    {
        var project = await _dbContext.Projects.FindAsync(dto.Id);
        if (project is null)
        {
            throw new NotFoundException($"Project with id {dto.Id} was not found.");
        }

        _mapper.Map(dto, project);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(long projectId)
    {
        var project = await _dbContext.Projects.FindAsync(projectId);
        if (project is not null)
        {
            _dbContext.Projects.Remove(project);
        }

        await _dbContext.SaveChangesAsync();
    }
}