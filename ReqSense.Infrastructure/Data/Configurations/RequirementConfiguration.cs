﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReqSense.Domain.Entities;

namespace ReqSense.Infrastructure.Data.Configurations;

public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
{
    public void Configure(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasOne(e => e.Creator)
            .WithMany(u => u.Requirements)
            .HasForeignKey(e => e.CreatedBy);

        builder.HasOne<Project>()
            .WithMany(p => p.Requirements)
            .HasForeignKey(e => e.ProjectId);
    }
}