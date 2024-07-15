using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReqSense.Application.Common.DTOs.User.Response;
using ReqSense.Application.Common.Exceptions;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Common;
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

    public async Task<UserInfoDto> GetUserInfoAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        NotFoundException.ThrowIfNull(user, $"User with id {userId} was not found.");
        return _mapper.Map<UserInfoDto>(user);
    }

    public async Task<string> CreateUserAsync(string userName, string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email
        };

        await _userManager.CreateAsync(user, password)
            .ThrowIfFailedAsync();

        return user.Id;
    }

    public void CreateUserAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(string userId, string role)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AuthenticateUserAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new IdentityException("Either the email or password is incorrect.");
        }

        var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
        return result.Succeeded;
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