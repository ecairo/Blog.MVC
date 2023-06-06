using Blog.Data.Infrastructure;

namespace Blog.Data.Repositories
{
    public class PostRespository : RepositoryBase<Entities.Post>, IPostRespository
    {
        public PostRespository(IDbFactory dbFactory)
            :base(dbFactory)
        {

        }
    }
}
