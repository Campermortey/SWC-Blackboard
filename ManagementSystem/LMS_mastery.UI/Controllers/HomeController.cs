using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS_mastery.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if they are logged in, take it to their dashboard
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "Teacher");
                }
            }
            return View();
        }

        
    }
}