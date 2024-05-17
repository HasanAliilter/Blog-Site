using BlogProject.Core.Entities;
using BlogProject.Entity.Entities;

namespace BlogProject.Entity.Entities
{
    public class Article : EntityBase
    {
        public Article()
        {
            
        }
        public Article(string title, string content, Guid categoryId, Guid userId, string createdBy, Guid imageId )
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
            UserId = userId;
            ImageId = imageId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}

