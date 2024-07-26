namespace ReqSense.Application.Features.ProjectMembers.DTOs;

public record ProjectMemberDto(
    string Name,
    string Email,
    string Role,
    DateTimeOffset JoinedDate);