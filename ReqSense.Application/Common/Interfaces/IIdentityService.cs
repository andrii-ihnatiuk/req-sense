using ReqSense.Application.Common.DTOs.User.Response;
using ReqSense.Domain.Common;
using ReqSense.Domain.Common.Interfaces;

namespace ReqSense.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<UserInfoDto>> GetUserInfoAsync(string userId);

    Task<Result<string>> CreateUserAsync(string userName, string email, string password);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<Result> AuthenticateUserAsync(string email, string password);

    Task LogoutAsync();

    Task DeleteUserAsync(string userId);

    Task DeleteUserAsync(IApplicationUser user);
}