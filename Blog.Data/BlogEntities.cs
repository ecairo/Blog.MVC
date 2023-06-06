using System;
using System.Data.Entity;

namespace Blog.Data
{
    public class BlogEntities : DbContext
    {
        public BlogEntities() : base("BlogEntities")
        {
        }

        public DbSet<Entities.Post> Posts { get; set; }

        public DbSet<Entities.Author> Authors { get; set; }

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
