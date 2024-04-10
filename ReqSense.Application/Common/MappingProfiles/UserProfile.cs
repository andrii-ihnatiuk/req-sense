using AutoMapper;
using ReqSense.Application.Common.DTOs.User.Response;
using ReqSense.Infrastructure.Identity;

namespace ReqSense.Application.Common.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserInfoDto>()
            .ForCtorParam(nameof(UserInfoDto.Name), opts => opts.MapFrom(src => src.UserName));
    }
}