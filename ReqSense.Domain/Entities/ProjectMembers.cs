using ReqSense.Domain.Constants;
using ReqSense.Infrastructure.Identity;

namespace ReqSense.Domain.Entities;

public partial class ProjectMembers
{
    public string MemberId { get; set; }

    public long ProjectId { get; set; }

    public string Role { get; set; }

    public DateTimeOffset JoinedDate { get; set; }

    public ApplicationUser Member { get; set; }

    public Project Project { get; set; }
}

public partial class ProjectMembers
{
    public static ProjectMembers Owner(string id, long projectId = default) => new ProjectMembers
    {
        MemberId = id,
        ProjectId = projectId,
        Role = Roles.Owner,
        JoinedDate = DateTimeOffset.Now,
    };
}