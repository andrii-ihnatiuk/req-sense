﻿using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.DTOs.Project.Response;

namespace ReqSense.Application.Common.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectBriefDto>> GetAllUserProjectsAsync(string userId);

    Task<ProjectFullDto> GetProjectAsync(long id);

    Task<long> CreateProjectAsync(CreateProjectDto dto);

    Task UpdateProjectAsync(UpdateProjectDto dto);

    Task DeleteProjectAsync(long projectId);
}