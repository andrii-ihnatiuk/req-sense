namespace ReqSense.Application.Common.DTOs.User.Request;

public record LoginDto(
    string Email,
    string Password);