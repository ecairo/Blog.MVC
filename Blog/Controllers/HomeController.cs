using Blog.Service;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorService authorService;

        public HomeController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public ActionResult Index(string name)
        {
            //ViewBag.QueryName = HttpContext.Request.QueryString.Get("name"); 

            ViewBag.QueryName = name;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}