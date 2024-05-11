using BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("46E64AA1-EF33-4ADE-84FD-E029A5464469"),
                RoleId = Guid.Parse("0EFE8CA4-1721-488A-AB5C-180A3DC1185A")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("B4DBCD88-B32F-4CC5-8AE3-046132C19F56"),
                RoleId = Guid.Parse("EB145ECA-C68E-4D60-8372-1A04792FF810")
            });
        }
    }
}
