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
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable(nameof(Roles));

            builder.HasKey(x => x.Id);

            builder.Property(r => r.RoleName).IsRequired();
            builder.Property(ur => ur.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(ur => ur.DateModified).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(ur => ur.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasMany(r => r.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId).IsRequired();
        }
    }
}
