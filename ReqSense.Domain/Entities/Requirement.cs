using ReqSense.Domain.Common;
using ReqSense.Domain.Entities.Identity;

namespace ReqSense.Domain.Entities;

public class Requirement : AuditableEntityBase
{
    public long ProjectId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public ApplicationUser Creator { get; set; }

    public ApplicationUser? LastEditor { get; set; }
}