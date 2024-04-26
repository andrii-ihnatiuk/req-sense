using AutoMapper;
using ReqSense.Application.Common.DTOs.Requirement.Request;
using ReqSense.Domain.Constants;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Common.MappingProfiles;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateMap<CreateRequirementDto, Requirement>()
            .ForMember(dest => dest.Status, opts => opts.MapFrom(_ => RequirementStatuses.Provided))
            .ForMember(dest => dest.Created, opts => opts.MapFrom(_ => DateTimeOffset.Now))
            .ForMember(dest => dest.LastModified, opts => opts.MapFrom(_ => DateTimeOffset.Now));
    }
}