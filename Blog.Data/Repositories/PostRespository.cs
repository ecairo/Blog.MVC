using Blog.Data.Infrastructure;

namespace Blog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Entities.Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            :base(dbFactory)
        {

        }
    }
}
