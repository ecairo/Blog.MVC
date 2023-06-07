using Blog.Data.Infrastructure;
using Blog.Data.Repositories;
using System.Collections.Generic;

namespace Blog.Service
{
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            this.authorRepository = authorRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Entities.Author> GetAuthors()
        {
            return this.authorRepository.GetAll();
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }
    }
}
