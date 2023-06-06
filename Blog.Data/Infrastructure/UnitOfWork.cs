namespace Blog.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private BlogEntities dataContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BlogEntities DbContext
        {
            get
            {
                return this.dataContext ?? (this.dataContext = dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
