using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReqSense.Domain.Entities;

namespace ReqSense.Infrastructure.Data.Configurations;

public class ProjectMembersConfiguration : IEntityTypeConfiguration<ProjectMembers>
{
    public void Configure(EntityTypeBuilder<ProjectMembers> builder)
    {
        builder.HasKey(e => new { UserId = e.MemberId, e.ProjectId });

        builder.HasOne(e => e.Member)
            .WithMany(x => x.Projects);
    }
}