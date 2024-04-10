namespace ReqSense.Application.Common.DTOs.User.Request;

public record RegistrationDto(
    string Name,
    string Email,
    string Password);