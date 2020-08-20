using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//THIS IS OUR CUSTOMIZED CONTROLLER

    //Secret
namespace MVCSecurityDemo.Controllers
{
    /*
     * if you apply [Authorize] to the controller itself as below, 
     * every action will require user to be authorized
     */

    //Authorize entire class by uncommenting below
    //[Authorize]

    //Authorize entire class to only a certain email by uncommenting below
    [Authorize(Users = "wkkahres@gmail.com")]
    public class SecretController : Controller
    {
        // GET: Secret
        //UPDATED CODE HERE - removed Action Result

        //Only Authenticated Users should get Secret

        //[Authorize] //<-- This makes sure identity of user is known and they're not anonymous
                    //    for this action method
        public ContentResult Secret()
        {
            return Content("Secret Information Here");
        }

        //Non Authenticated Users should get Public
        
            /*[AllowAnonymous] allows this action method to be public even if the rest of the 
         * class requires Authorization
         */

        [AllowAnonymous]
        public ContentResult PublicInfo()
        {
            return Content("Public Information Here");
        }


        
    }
}