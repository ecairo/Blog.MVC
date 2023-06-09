using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Blog.Data
{
    public class BlogEntities : IdentityDbContext<Entities.ApplicationUser>
    {
        public BlogEntities() : base("BlogEntities")
        {

        }

        public DbSet<Entities.Post> Posts { get; set; }

        public DbSet<Entities.Author> Authors { get; set; }

        public DbSet<Entities.Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new Configuration.PostConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
