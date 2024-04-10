using AutoMapper;
using ReqSense.Application.Common.DTOs.Project.Request;
using ReqSense.Application.Common.DTOs.Project.Response;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Common.MappingProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();

        CreateMap<UpdateProjectDto, Project>();

        CreateMap<Project, ProjectBriefDto>();

        CreateMap<Project, ProjectFullDto>();
    }
}