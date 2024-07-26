namespace ReqSense.Application.Features.Projects.DTOs;

public record ProjectListItemDto(
    long Id,
    string Title,
    string? Description,
    string Owner,
    int MembersCount);