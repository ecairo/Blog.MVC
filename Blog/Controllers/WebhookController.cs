using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class WebhookController : Controller
    {
        
        [HttpPost]
        public ActionResult ReceivePaymentNotification(/* Definir el objeto y hacer bind */)
        {
            // procesar lo que viene en el POST

            return new HttpStatusCodeResult(200);
        }
    }
}