using Microsoft.EntityFrameworkCore;
using ReqSense.Domain.Entities;

namespace ReqSense.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Project> Projects { get; }

    DbSet<ProjectMembers> ProjectsMembers { get; }

    DbSet<Requirement> Requirements { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}