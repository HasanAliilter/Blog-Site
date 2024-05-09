using BlogProject.Data.Mapping;
using BlogProject.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogProject.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected AppDbContext()
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Article>().Property(x=> x.Title).HasMaxLength(150);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Tüm mapping sınıfları tanımlanır
        }
    }
}
