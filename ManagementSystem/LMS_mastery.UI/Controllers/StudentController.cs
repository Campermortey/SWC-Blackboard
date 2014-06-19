using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_mastery.Data;
using Microsoft.AspNet.Identity;

namespace LMS_mastery.UI.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index()
        {
            var repository = new StudentRepository();

            // get the list of courses. Pass in UserId
            var courses = repository.GetStudentClasses(User.Identity.GetUserId());
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