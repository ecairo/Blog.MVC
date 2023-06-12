using AutoMapper;
using Blog.Data.Infrastructure;
using Blog.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.WebApiControllers
{
    [RoutePrefix("api/posts/{id}")]
    public class PostsController : ApiController
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        //[Route("{pageNumber:int:min(1)}/{pageSize:int:min(10)}")]
        public IHttpActionResult /*IEnumerable<ViewModels.PostViewModel>*/ Get(int pageNumber = 1, int pageSize = 10)
        {
            var page = new Page(pageNumber, pageSize);

            var postsEntities = this.postService.GetPosts(page);

            return Ok(this.mapper.Map<IEnumerable<Entities.Post>, IEnumerable<ViewModels.PostViewModel>>(postsEntities));
        }

        public IHttpActionResult Get(Guid id)
        {
            var postEntity = this.postService.GetPost(id);

            if(postEntity == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<Entities.Post, ViewModels.PostViewModel>(postEntity));
        }


        /*
         *  
         * 
         *  POST - Crear => No Idempotente
         *  GET - Obtener - Idempotente
         *  PUT - Actualizar - Idempotente
         *      
         *  DELETE - Eliminar - Idempotente
         *  PATCH - Partial Update - Idempotente
         *          Posts
         *              - Title  "Updated"
         *              /posts/
         *              op: replace
         *                  - path: "Title"
         *                  - value: "New Title" 
         *              - Content
         */
    }
}
