using ReqSense.Domain.Common;

namespace ReqSense.Domain.Entities;

public class Requirement : AuditableEntityBase
{
    public long ProjectId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public string CreatorId { get; set; }
}