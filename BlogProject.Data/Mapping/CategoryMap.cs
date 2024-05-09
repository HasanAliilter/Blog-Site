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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("933B9554-CC1B-4715-97C9-9A1A85DB9BC5"),
                Name = "C#",
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Category
            {
                Id = Guid.Parse("301DE9F5-8A72-4738-863E-4104123917F7"),
                Name = "Sql Server",
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
