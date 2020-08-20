using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCFiltersDemo.ActionFilters; //add this to connect to custom actionfilter file

namespace MVCFiltersDemo.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        /*public ActionResult Index()
        {
            return View();
        }
        */

        [OutputCache(Duration = 10)]
        //use this for FILTER demo
        public string Index()
        {
            return "This is ASP.Net MVC Filters Tutorial";
        }

        /*[OutputCache(Duration = 10)] 
         * //Use this for filter demo
         * */
         
        //SELECTOR DEMO
        [ActionName("CurrentTime")] //Action - Use this for Action demo 
        //uses a different action than the method name : localhost:5668/Home/CurrentTime
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }
        
        /*
        [NonAction] //NonAction Method
        //indicates that a public method of a controller is not an action method
        public string TimeString()
        {
            return "Time is " + DateTime.Now.ToString("T");
        }
        */
    }
}