using Blog.Service;
using System;
using System.Collections.Generic;

namespace Blog.Tests
{
    public class MockedAuthorService : IAuthorService
    {
        public void AddAuthor(Blog.Entities.Author authorEntity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(Blog.Entities.Author author)
        {
            throw new NotImplementedException();
        }

        public Blog.Entities.Author FindAuthor(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog.Entities.Author> GetAuthors()
        {
            return new List<Entities.Author>();
        }

        public void UpdateAuthor(Blog.Entities.Author authorEntity)
        {
            throw new NotImplementedException();
        }
    }
}