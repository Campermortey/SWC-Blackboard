using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_mastery.Data;
using Microsoft.AspNet.Identity;

namespace LMS_mastery.UI.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            var repository = new TeacherRepository();
            var courses = repository.GetSectionsFor(User.Identity.GetUserId());
            return View(courses);
        }
	}
}