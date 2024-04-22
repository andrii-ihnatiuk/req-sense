using ReqSense.Domain.Common;

namespace ReqSense.Domain.Entities;

public class Project : EntityBase
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public ICollection<ProjectMembers> Members { get; set; } = new List<ProjectMembers>();

    public ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
}