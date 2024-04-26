using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReqSense.Domain.Entities;

namespace ReqSense.Infrastructure.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasIndex(e => e.Title).IsUnique();

        builder.Property(e => e.Title)
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(200);
    }
}