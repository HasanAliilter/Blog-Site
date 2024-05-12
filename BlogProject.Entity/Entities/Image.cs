using BlogProject.Core.Entities;

namespace BlogProject.Entity.Entities
{
    public class Image : EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
