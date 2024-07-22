using ReqSense.Domain.Entities;

namespace ReqSense.Domain.Common.Interfaces;

public interface IApplicationUser
{
    string? UserName { get; set; }

    string? Email { get; set; }

    ICollection<ProjectMembers> Projects { get; set; }
}