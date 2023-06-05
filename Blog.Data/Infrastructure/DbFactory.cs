namespace Blog.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BlogEntities blogDbContextp;

        public BlogEntities Init()
        {
            return this.blogDbContextp ?? (this.blogDbContextp = new BlogEntities());
        }

        protected override void DisposeCore()
        {
            if (this.blogDbContextp != null)
            {
                this.blogDbContextp.Dispose();
            }
        }
    }
}
