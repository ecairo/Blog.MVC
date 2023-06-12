using Blog.Data.Infrastructure;
using Blog.Data.Repositories;
using Blog.Entities;
using System;
using System.Collections.Generic;

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

        public void CreatePost(Post postEntity)
        {
            this.postRepository.Add(postEntity);
        }

        public Post GetPost(Guid id)
        {
            return this.postRepository.GetById(id);
        }

        public IEnumerable<Entities.Post> GetPosts(Page page)
        {
            return this.postRepository.GetPage(page, post => true, post => post.UpdatedAt);
        }

        public void Commit()
        {
            this.unitOfWork.Commit();
        }
    }
}
