using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFiltersDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        /*public ActionResult Index()
        {
            return View();
        }
        */

        /*ACTION VERBS 
         * HttpGet
         * HttpPost
         * HttpPut
         * HttpDelete
         * HttpOptions
         * HttpPatch
        */

        /*
        public ActionResult Search(string name = "No Name Entered")
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
        */

        //Without [HttpGet, MVC doesn't know which action method should be picked up for the request
        public ActionResult Search(string name)
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
    
        [HttpGet] //use this to specify response
        public ActionResult Search()
        {
            var input = "Another Search action";
            return Content(input);
        }
    
    }
}