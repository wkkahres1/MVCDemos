using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControllerDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /*public ActionResult Index()
        {
            return View();
        }
        */

        //Just prints this on thes screen
        /*public string Index()
        {
            return "This is the Home Controller";
        }
        */

        //Reroutes to another Controller
        public ActionResult Index()
        {
            return RedirectToAction("GetAllCustomers", "Customer");
            //Redirect to Action method ActionResult takes two parameters, action name and and controller name
        }
    }   
}