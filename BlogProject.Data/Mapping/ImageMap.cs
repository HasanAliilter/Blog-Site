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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("F91B9913-A95D-4C7C-A204-E1D32A151C72"),
                FileName = "Images/hasanimage",
                FileType = "jpg",
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Image
            {
                Id = Guid.Parse("EFEDF71D-350E-4869-BFAA-6D0E24F1014D"),
                FileName = "Images/sqltest",
                FileType = "jpg",
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
