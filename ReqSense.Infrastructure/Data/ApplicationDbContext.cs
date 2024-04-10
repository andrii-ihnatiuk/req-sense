using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Entities;
using ReqSense.Infrastructure.Identity;

namespace ReqSense.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectMembers> ProjectsMembers => Set<ProjectMembers>();

    public DbSet<Requirement> Requirements => Set<Requirement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}