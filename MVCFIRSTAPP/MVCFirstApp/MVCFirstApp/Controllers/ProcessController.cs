﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        /*public ActionResult Index()
        {
            return View();
        }
        */
        public string List()
        {
            return "This is a Process Page";
        }
   
    }
}