using AutoMapper;
using ReqSense.Application.Features.Projects.Commands.Create;
using ReqSense.Application.Features.Projects.Commands.Update;
using ReqSense.Application.Features.Projects.DTOs;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Common.MappingProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateDtoToModelMappings();
        CreateModelToDtoMappings();
    }

    private void CreateDtoToModelMappings()
    {
        CreateMap<CreateProjectCommand, Project>();

        CreateMap<UpdateProjectCommand, Project>();
    }

    private void CreateModelToDtoMappings()
    {
        CreateMap<Project, ProjectBriefDto>();

        CreateMap<Project, ProjectFullDto>();
    }
}