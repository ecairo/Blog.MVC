using System.Collections.Generic;

namespace Blog.Service
{
    public interface IAuthorService
    {
        void Commit();

        IEnumerable<Entities.Author> GetAuthors();
    }
}