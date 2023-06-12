using Blog.Data.Infrastructure;
using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Service
{
    public interface IPostService
    {
        IEnumerable<Entities.Post> GetPosts(Page page);
        Entities.Post GetPost(Guid id);
        void CreatePost(Entities.Post postEntity);
        void Commit();
        void Update(Post postEntityUpdated);
    }
}