using Microsoft.AspNetCore.Identity;

namespace BlogProject.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("a2c89e53-7271-451c-9c56-c35751aa00ea");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
