using Microsoft.AspNetCore.Identity;
using ReqSense.Domain.Common;

namespace ReqSense.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser, IApplicationUser
{
    public ICollection<ProjectMembers> Projects { get; set; }

    public ICollection<Requirement> Requirements { get; set; }
}