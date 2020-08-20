using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViewsDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string /*ActionResult*/ Index()
        {
            //return View();
            return "This is the index.";
        }

        public string MyController()
        {
            return "Hi, I am a controller";
        }

        public ActionResult MyView()
        {
            return View();
        }
    }
}