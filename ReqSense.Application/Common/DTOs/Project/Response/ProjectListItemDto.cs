namespace ReqSense.Application.Common.DTOs.Project.Response;

public record ProjectListItemDto(
    long Id,
    string Title,
    string? Description,
    string Owner,
    int MembersCount);