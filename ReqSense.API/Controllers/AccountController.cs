using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        var info = await _identityService.GetUserInfoAsync(_currentUser.Id!);
        return Ok(info);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        var userId = await _identityService.CreateUserAsync(dto.Name, dto.Email, dto.Password);
        return Ok(new { id = userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!await _identityService.AuthenticateUserAsync(dto.Email, dto.Password))
        {
            return BadRequest();
        }

        var info = await _identityService.GetUserInfoAsync(_currentUser.Id!);
        return Ok(info);
    }
}