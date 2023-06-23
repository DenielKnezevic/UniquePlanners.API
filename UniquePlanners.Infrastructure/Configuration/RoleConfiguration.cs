using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities;
using UniquePlanners.Core.Helpers;

namespace UniquePlanners.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable(nameof(Roles));

            builder.HasKey(x => x.Id);

            builder.Property(r => r.RoleName).IsRequired();
            builder.Property(ur => ur.DateCreated).IsRequired();
            builder.Property(ur => ur.DateModified).IsRequired();
            builder.Property(ur => ur.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasMany(r => r.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId).IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Roles> builder)
        {
            var adminRole = new Roles { Id = 1, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, IsDeleted = false, RoleName = RoleNames.ADMIN, Description = "" };

            builder.HasData(adminRole);
        }
    }
}
