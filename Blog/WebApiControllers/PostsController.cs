using Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.WebApiControllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public string Get()
        {
            return "Hello from posts";
        }
    }
}
