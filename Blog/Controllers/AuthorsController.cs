using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Blog.Service;

namespace Blog.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }


        // GET: Authors
        public ActionResult Index()
        {
            var authorsFromService = this.authorService.GetAuthors();

            // Con AutoMapper
            var authorsViewModel = this.mapper.Map<IEnumerable<Entities.Author>, IEnumerable<ViewModels.AuthorViewModel>>(authorsFromService);

            // Sin AutoMapper
            //foreach (var authorEntity in authorsFromService)
            //{
            //    authorsViewModel.Add(new ViewModels.AuthorViewModel()
            //    {
            //        Id = authorEntity.Id,
            //        FullName = authorEntity.Name + " " + authorEntity.FirstName + " " + authorEntity.LastName,
            //        Email = authorEntity.Email
            //    });
            //}

            return View(authorsViewModel);
        }

        
        // GET: Authors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = this.authorService.FindAuthor(id.Value);
            
            if (author == null)
            {
                return HttpNotFound();
            }

            var authorDetailViewModel = this.mapper.Map<Entities.Author, ViewModels.AuthorDetailViewModel>(author);

            return View(authorDetailViewModel);
        }

        
        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,FirstName,LastName,Email,GravatarUrl")] ViewModels.AuthorFormViewModel authorForm)
        {
            if (ModelState.IsValid)
            {
                var authorEntity = this.mapper.Map<ViewModels.AuthorFormViewModel, Entities.Author>(authorForm);

                authorEntity.Id = Guid.NewGuid();

                this.authorService.AddAuthor(authorEntity);

                this.authorService.Commit();

                return RedirectToAction("Index");
            }

            return View(authorForm);
        }
        
        // GET: Authors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = this.authorService.FindAuthor(id.Value);

            if (author == null)
            {
                return HttpNotFound();
            }

            var authorEditFormViewModel = this.mapper.Map<Entities.Author, ViewModels.AuthorEditFormViewModel>(author);

            return View(authorEditFormViewModel);
        }

        
        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [Bind(Include = "Name,FirstName,LastName,GravatarUrl")] ViewModels.AuthorEditFormViewModel authorEditFormView)
        {
            var author = this.authorService.FindAuthor(id);

            if (author == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {                
                var authorEntity = this.mapper.Map<ViewModels.AuthorEditFormViewModel, Entities.Author>(authorEditFormView, author);
                
                this.authorService.UpdateAuthor(authorEntity);

                this.authorService.Commit();

                return RedirectToAction("Index");
            }

            return View(authorEditFormView);
        }
        
        // GET: Authors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = this.authorService.FindAuthor(id.Value);

            if (author == null)
            {
                return HttpNotFound();
            }

            var authorDetailsViewModel = this.mapper.Map<Entities.Author, ViewModels.AuthorDetailViewModel>(author);

            return View(authorDetailsViewModel);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var author = this.authorService.FindAuthor(id);
            this.authorService.DeleteAuthor(author);
            this.authorService.Commit();

            return RedirectToAction("Index");
        }
    }
}
