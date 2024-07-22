using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReqSense.Application.Common.DTOs.User.Response;
using ReqSense.Application.Common.Errors;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Common;
using ReqSense.Domain.Common.Interfaces;
using ReqSense.Domain.Entities.Identity;

namespace ReqSense.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<Result<UserInfoDto>> GetUserInfoAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return Result.Fail<UserInfoDto>(UserErrors.NotFound(userId));
        }

        return Result.Ok(_mapper.Map<UserInfoDto>(user));
    }

    public async Task<Result<string>> CreateUserAsync(string userName, string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email
        };

        var identityResult = await _userManager.CreateAsync(user, password);
        return identityResult.Succeeded
            ? Result.Ok(user.Id)
            : Result.Fail<string>(UserErrors.Validation(identityResult.Errors.Select(e => e.ToResultError())));
    }

    public void CreateUserAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(string userId, string role)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> AuthenticateUserAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return Result.Fail(UserErrors.InvalidCredentials());
        }

        var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
        return result.Succeeded ? Result.Ok() : Result.Fail(UserErrors.InvalidCredentials());
    }

    public Task LogoutAsync()
    {
        return _signInManager.SignOutAsync();
    }

    public Task DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(IApplicationUser user)
    {
        throw new NotImplementedException();
    }
}