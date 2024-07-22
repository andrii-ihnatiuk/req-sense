using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.DTOs.Project.Response;

namespace ReqSense.Application.Common.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectListItemDto>> GetUserProjectsAsync(string userId, string filter);

    Task<Result<ProjectFullDto>> GetProjectAsync(long id);

    Task<ProjectInsightsDto> GetProjectInsightsAsync(long id);

    Task<IEnumerable<ProjectMemberDto>> GetProjectMembersAsync(long id, int? limit);

    Task<Result<long>> CreateProjectAsync(CreateProjectDto dto);

    Task<Result> UpdateProjectAsync(UpdateProjectDto dto);

    Task<Result> DeleteProjectAsync(long projectId);
}