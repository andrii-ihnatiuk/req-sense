namespace ReqSense.Application.Common.DTOs.Project.Response;

public record ProjectMemberDto(
    string Name,
    string Email,
    string Role,
    DateTimeOffset JoinedDate);