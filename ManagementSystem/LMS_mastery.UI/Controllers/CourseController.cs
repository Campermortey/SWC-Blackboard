using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS_mastery.UI.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Gradebook(int id)
        {
            return View();
        }

        public ActionResult Assignments(int id)
        {
            return View();
        }

        public ActionResult AddAssignment(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAssignment()
        {
            return RedirectToAction("Assignments");
        }

        public ActionResult EditAssignment(int id)
        {
            return RedirectToAction("Assignments");
        }
	}
}