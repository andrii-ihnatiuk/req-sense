using ReqSense.Application.Common.Errors.Base;

namespace ReqSense.Application.Common.Errors;

public static class ProjectErrors
{
    public static NotFoundError NotFound(long id) =>
        new("Project.NotFound", $"The project with id {id} was not found.");

    public static DuplicateEntryError DuplicateTitle(string title) =>
        new("Project.Duplicate", $"The project with title '{title}' already exists.");
}