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
    public class PlannerConfiguration : IEntityTypeConfiguration<Planner>
    {
        public void Configure(EntityTypeBuilder<Planner> builder)
        {
            builder.ToTable(nameof(Planner));
            
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.PlannerCovers).WithOne(pc => pc.Planner).HasForeignKey(pc => pc.PlannerId).IsRequired();
            builder.HasOne(p => p.User).WithMany(u => u.Planners).HasForeignKey(p => p.UserId).IsRequired();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.DateModified).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
