using ReqSense.Application.Common.Errors.Base;

namespace ReqSense.Application.Common.Errors;

public static class RequirementErrors
{
    public static NotFoundError NotFound(long id) =>
        new("Requirement.NotFound", $"The requirement with id {id} was not found.");

    public static DuplicateEntryError DuplicateTitle(string title) =>
        new("Requirement.Duplicate", $"The requirement with title '{title}' already exists.");
}