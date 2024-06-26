﻿using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.DTOs.Project.Response;

namespace ReqSense.Application.Common.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectListItemDto>> GetUserProjectsAsync(string userId, string filter);

    Task<ProjectFullDto> GetProjectAsync(long id);

    Task<ProjectInsightsDto> GetProjectInsightsAsync(long id);

    Task<IEnumerable<ProjectMemberDto>> GetProjectMembersAsync(long id, int? limit);

    Task<long> CreateProjectAsync(CreateProjectDto dto);

    Task UpdateProjectAsync(UpdateProjectDto dto);

    Task DeleteProjectAsync(long projectId);
}