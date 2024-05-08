using BlogProject.Core.Entities;

namespace BlogProject.Entity.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
