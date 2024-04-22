using Microsoft.AspNetCore.Identity;
using ReqSense.Domain.Common;
using ReqSense.Domain.Entities;

namespace ReqSense.Infrastructure.Identity;

public class ApplicationUser : IdentityUser, IApplicationUser
{
    public ICollection<ProjectMembers> Projects { get; set; }

    public ICollection<Requirement> Requirements { get; set; }
}