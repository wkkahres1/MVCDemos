﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello World. this ASP.Net MVC Tutorials";
        }
       /* public ActionResult Index()
        {
            return View();
        }
        */
    }
}