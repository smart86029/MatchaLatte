﻿using Manager.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasData(GetSeedData());
        }

        private Role[] GetSeedData()
        {
            var result = new Role[]
            {
                new Role { RoleId = 1, Name = "Administrator", IsEnabled = true },
                new Role { RoleId = 2, Name = "HumanResources", IsEnabled = true }
            };

            return result;
        }
    }
}