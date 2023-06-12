using AutoMapper;
using Blog.Data.Infrastructure;
using Blog.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.WebApiControllers
{
    [RoutePrefix("api/posts")]
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
        [Route("")]
        public IHttpActionResult /*IEnumerable<ViewModels.PostViewModel>*/ Get(int pageNumber = 1, int pageSize = 10)
        {
            var page = new Page(pageNumber, pageSize);

            var postsEntities = this.postService.GetPosts(page);

            return Ok(this.mapper.Map<IEnumerable<Entities.Post>, IEnumerable<ViewModels.PostViewModel>>(postsEntities));
        }

        [Route("{id}", Name = "GetPost")]
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
        [Route("", Name = "PostCreation")]
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

        [HttpPut]
        [Route("{id}", Name = "UpdatePost")]
        public IHttpActionResult Put(Guid id, ViewModels.PostToUpdateViewModel postToUpdateViewModel)
        {
            var postToUpdate = this.postService.GetPost(id);

            if (postToUpdate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            // User has permissions to update

            var postEntityUpdated = this.mapper.Map<ViewModels.PostToUpdateViewModel, Entities.Post>(postToUpdateViewModel, postToUpdate);

            this.postService.Update(postEntityUpdated);

            this.postService.Commit();

            var postViewModel = this.mapper.Map<Entities.Post, ViewModels.PostViewModel>(postEntityUpdated);

            return Ok(postViewModel);
        }

        [HttpDelete]
        [Route("{id}", Name = "DeletePost")]
        public IHttpActionResult Put(Guid id)
        {
            throw new NotImplementedException();
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
