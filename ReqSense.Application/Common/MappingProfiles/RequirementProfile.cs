using AutoMapper;
using ReqSense.Application.Features.Requirements.Commands.Create;
using ReqSense.Application.Features.Requirements.Commands.Update;
using ReqSense.Application.Features.Requirements.DTOs;
using ReqSense.Domain.Constants;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Common.MappingProfiles;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateDtoToModelMappings();
        CreateModelToDtoMappings();
    }

    private void CreateDtoToModelMappings()
    {
        CreateMap<CreateRequirementCommand, Requirement>()
            .ForMember(dest => dest.Status, opts => opts.MapFrom(_ => RequirementStatuses.Provided))
            .ForMember(dest => dest.ProjectId, opts => opts.MapFrom(src => src.ProjectId));

        CreateMap<UpdateRequirementCommand, Requirement>();
    }

    private void CreateModelToDtoMappings()
    {
        CreateMap<Requirement, RequirementBriefDto>()
            .ForCtorParam(nameof(RequirementBriefDto.CreatorName), opts => opts.MapFrom(src => src.Creator.UserName));

        CreateMap<Requirement, RequirementFullDto>()
            .ForCtorParam(nameof(RequirementFullDto.CreatorName), opts => opts.MapFrom(src => src.Creator.UserName))
            .ForCtorParam(nameof(RequirementFullDto.LastEditorName),
                opts => opts.MapFrom(src => src.LastEditor != null ? src.LastEditor.UserName : null));
    }
}