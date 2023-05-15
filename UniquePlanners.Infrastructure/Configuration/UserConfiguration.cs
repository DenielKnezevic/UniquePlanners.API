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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.DateCreated).IsRequired();
            builder.Property(u => u.DateModified).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId).IsRequired();
            builder.HasMany(u => u.Planners).WithOne(p => p.User).HasForeignKey(p => p.UserId).IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<User> builder)
        {
            var userAdmin = new User { Id = 1, IsDeleted = false, DateCreated = DateTime.Now, DateModified = DateTime.Now, DayOfBirth = DateTime.Now, Email = "admin@planners.com", FirstName = "Admin" , LastName = "Admin", PasswordSalt = "EXbj3Fr+QN6AbRkoJFX/QA==", PasswordHash = "rvvcYpaiMwQyQqY4J3rLNRBerJw=", PhoneNumber = "+387000000", Username = "User" };

            builder.HasData(userAdmin);
        }
    }
}
