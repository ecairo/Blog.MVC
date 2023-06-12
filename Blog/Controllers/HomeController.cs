using Blog.Attributes;
using Blog.Service;
using log4net;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly ILog logger;

        public HomeController(IAuthorService authorService, ILog logger)
        {
            this.authorService = authorService;
            this.logger = logger;
        }

        [HttpGet]
        [I18N]
        public ActionResult Index(string name)
        {
            //ViewBag.QueryName = HttpContext.Request.QueryString.Get("name"); 
            this.logger.Info("Hello from Home controller index");

            ViewBag.HomeLinkTranslated = Strings.HomeLink;

            ViewBag.QueryName = name;
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}