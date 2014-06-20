using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_mastery.Data;
using Microsoft.AspNet.Identity;

namespace LMS_mastery.UI.Controllers
{
    public class ParentController : Controller
    {
        //
        // GET: /Parent/
        public ActionResult Index()
        {
            var repository = new ParentRepository();

            // get the list of courses. Pass in UserId
            var children = repository.GetChildren(User.Identity.GetUserId());
            return View(children);
        }
        public ActionResult Classes(string id)
        {
            var repository = new StudentRepository();

            // get the list of courses. Pass in UserId
            var courses = repository.GetStudentClasses(id);
            return View(courses);
        }

        public ActionResult Grades(int id)
        {
            var repository = new StudentRepository();

            var courses = repository.GetStudentGrades(id);
            return View(courses);
        }
	}
}