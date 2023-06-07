using System.Collections.Generic;
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

        /*
        // GET: Authors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
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
        public ActionResult Create([Bind(Include = "Id,Name,FirstName,LastName,Email,GravatarUrl,CreatedAt,UpdatedAt")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FirstName,LastName,Email,GravatarUrl,CreatedAt,UpdatedAt")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
