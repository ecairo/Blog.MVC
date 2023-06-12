using AutoMapper;
using Blog.Data.Infrastructure;
using Blog.Service;
using Microsoft.AspNet.Identity;
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

        [Route(Name = "GetPost")]
        public IHttpActionResult Get(Guid id)
        {
            var postEntity = this.postService.GetPost(id);

            if(postEntity == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<Entities.Post, ViewModels.PostViewModel>(postEntity));
        }

        [HttpPost]
        public IHttpActionResult Post(ViewModels.PostToCreationViewModel postToCreationViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var postEntity = this.mapper.Map<ViewModels.PostToCreationViewModel, Entities.Post>(postToCreationViewModel);
            var postId = Guid.NewGuid();

            postEntity.Id = postId;

            //var authorId = User.Identity.GetUserId();

            postEntity.AuthorId = Guid.Parse("d64d0d6e-ba3c-47f1-a9f7-d573d5999bcd");

            this.postService.CreatePost(postEntity);

            this.postService.Commit();

            var postViewModel = this.mapper.Map<Entities.Post, ViewModels.PostViewModel>(this.postService.GetPost(postId));

            return CreatedAtRoute("GetPost", new { id = postId }, postViewModel);
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
