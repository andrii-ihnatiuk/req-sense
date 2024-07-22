using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReqSense.API.Extensions;
using ReqSense.Application.Common.DTOs.User.Request;
using ReqSense.Application.Common.Interfaces;

namespace ReqSense.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly ICurrentUser _currentUser;

    public AccountController(IIdentityService identityService, ICurrentUser currentUser)
    {
        _identityService = identityService;
        _currentUser = currentUser;
    }

    [Authorize]
    [HttpGet("info")]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        var infoResult = await _identityService.GetUserInfoAsync(_currentUser.Id!);
        return infoResult.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        var result = await _identityService.CreateUserAsync(dto.Name, dto.Email, dto.Password);
        return result.Match(
            onSuccess: id => Ok(new { id }),
            onFail: this.FromError);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var authResult = await _identityService.AuthenticateUserAsync(dto.Email, dto.Password);
        if (authResult.IsFailure)
        {
            return this.FromError(authResult.Error);
        }

        var infoResult = await _identityService.GetUserInfoAsync(_currentUser.Id!);
        return infoResult.Match(onSuccess: Ok, onFail: this.FromError);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _identityService.LogoutAsync();
        return NoContent();
    }
}