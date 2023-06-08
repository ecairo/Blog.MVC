using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Service
{
    public interface IAuthorService
    {
        void Commit();

        IEnumerable<Entities.Author> GetAuthors();

        Entities.Author FindAuthor(Guid id);

        void AddAuthor(Author authorEntity);

        void UpdateAuthor(Author authorEntity);
        void DeleteAuthor(Author author);
    }
}