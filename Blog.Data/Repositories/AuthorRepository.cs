using Blog.Data.Infrastructure;

namespace Blog.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Entities.Author>, IAuthorRepository
    {
        public AuthorRepository(IDbFactory dbFactory)
            :base(dbFactory) {   }
    }
}
