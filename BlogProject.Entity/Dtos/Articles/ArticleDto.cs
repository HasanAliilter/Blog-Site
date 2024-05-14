using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Entities;

namespace BlogProject.Entity.Dtos.Articles
{
    public class ArticleDto //Entity içinde oluşturduk ünkü katmanlar arası referanslar tek yönlü
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public CategoryDto Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
