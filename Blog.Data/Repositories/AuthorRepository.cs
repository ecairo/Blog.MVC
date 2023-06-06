using Blog.Data.Infrastructure;

namespace Blog.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Entities.Author>, IAuthorRespository
    {
        public AuthorRepository(IDbFactory dbFactory)
            :base(dbFactory) {   }
    }
}
