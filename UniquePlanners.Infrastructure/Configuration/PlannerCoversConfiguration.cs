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
    public class PlannerCoversConfiguration : IEntityTypeConfiguration<PlannerCovers>
    {
        public void Configure(EntityTypeBuilder<PlannerCovers> builder)
        {
            builder.ToTable(nameof(PlannerCovers));

            builder.HasKey(x => x.Id);

            builder.Property(pc => pc.Cover).IsRequired();
            builder.Property(pc => pc.PlannerId).IsRequired();
            builder.Property(pc => pc.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(pc => pc.DateModified).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(pc => pc.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasOne(pc => pc.Planner).WithMany(p => p.PlannerCovers).HasForeignKey(pc => pc.PlannerId).IsRequired();
        }
    }
}
