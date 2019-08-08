﻿using MatchaLatte.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Metadata
                .FindNavigation(nameof(Role.UserRoles))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Role.RolePermissions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}