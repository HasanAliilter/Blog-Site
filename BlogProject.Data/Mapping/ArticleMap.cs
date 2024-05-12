using BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "C# Makale",
                Content = "Lorem ipsum dolor sit amet",
                ViewCount = 13,
                CategoryId = Guid.Parse("933B9554-CC1B-4715-97C9-9A1A85DB9BC5"),
                ImageId = Guid.Parse("F91B9913-A95D-4C7C-A204-E1D32A151C72"),
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted= false,
                UserId = Guid.Parse("46E64AA1-EF33-4ADE-84FD-E029A5464469")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Sql Server Makale",
                Content = "Lorem ipsum dolor sit amet mxalknclcnaljcnlscnlxclnaslcnaslcnc sql server",
                ViewCount = 25,
                CategoryId = Guid.Parse("301DE9F5-8A72-4738-863E-4104123917F7"),
                ImageId= Guid.Parse("EFEDF71D-350E-4869-BFAA-6D0E24F1014D"),
                CreatedBy = "Admin Hasan",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("B4DBCD88-B32F-4CC5-8AE3-046132C19F56")
            });
            //builder.Property(x=> x.Title).HasMaxLength(150);
            //builder.Property(x=> x.Title).IsRequired(false);
        }
    }
}
