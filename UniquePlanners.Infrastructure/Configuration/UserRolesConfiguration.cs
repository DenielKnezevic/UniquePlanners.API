using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities;

namespace UniquePlanners.Infrastructure.Configuration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable(nameof(UserRoles));

            builder.HasKey(x => x.Id);

            builder.Property(ur => ur.DateCreated).IsRequired();
            builder.Property(ur => ur.DateModified).IsRequired();
            builder.Property(ur => ur.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(ur => ur.RoleId).IsRequired();
            builder.Property(ur => ur.UserId).IsRequired();

            builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();
            builder.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
        }
    }
}
