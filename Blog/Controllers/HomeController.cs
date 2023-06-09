using Blog.Service;
using log4net;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly ILog logger;

        public HomeController(IAuthorService authorService, ILog logger)
        {
            this.authorService = authorService;
            this.logger = logger;
        }

        public ActionResult Index(string name)
        {
            //ViewBag.QueryName = HttpContext.Request.QueryString.Get("name"); 
            this.logger.Info("Hello from Home controller index");

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