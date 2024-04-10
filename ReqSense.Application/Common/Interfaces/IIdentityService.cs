using ReqSense.Application.Common.DTOs.User.Response;
using ReqSense.Domain.Common;

namespace ReqSense.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<UserInfoDto> GetUserInfoAsync(string userId);

    Task<string> CreateUserAsync(string userName, string email, string password);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthenticateUserAsync(string email, string password);

    Task DeleteUserAsync(string userId);

    Task DeleteUserAsync(IApplicationUser user);
}