using Blog.Data.Infrastructure;
using Blog.Data.Repositories;

namespace Blog.Service
{
    public class PostService: IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
