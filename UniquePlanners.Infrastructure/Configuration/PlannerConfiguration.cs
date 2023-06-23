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
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.DateCreated).IsRequired();
            builder.Property(p => p.DateModified).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Price).IsRequired();

            seedData(builder);

        }

        private void seedData(EntityTypeBuilder<Planner> builder)
        {
            List<Planner> planner = new List<Planner>
            {
                new Planner { Id = 1, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, IsDeleted = false, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", Name = "Dnevni planer", Price = 20, UserId = 1 },
                new Planner { Id = 2, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow, IsDeleted = false, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", Name = "Poslovni planer", Price = 20, UserId = 1 }
            };

            builder.HasData(planner);
        }
    }
}
