using System.Data.Entity;

namespace Blog.Data
{
    public class BlogEntities : DbContext
    {
        public BlogEntities() : base("BlogEntities")
        {
        }

        public DbSet<Entities.Post> Posts { get; set; }
    }
}
