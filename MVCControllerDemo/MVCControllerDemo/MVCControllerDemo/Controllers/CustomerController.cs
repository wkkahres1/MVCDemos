using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControllerDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        /*public ActionResult Index()
        {
            return View();
        }
        */
        public string GetAllCustomers()
        {
            return @"<ul>
                        <li>Georgie the Hamster </li>
                        <li>Cayden Rountree </li>
                        <li>Breanna Rountree </li>
                        <li>Amber Rountree </li>
                    </ul>";
        }
    }
}