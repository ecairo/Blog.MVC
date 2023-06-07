namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Data.BlogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Data.BlogEntities context)
        {
            //  This method will be called after migrating to the latest version.
            BlogInitializer.GetAuthors().ForEach(a => context.Authors.AddOrUpdate(a));

            context.Commit();
        }
    }
}
