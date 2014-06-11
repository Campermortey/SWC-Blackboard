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
            var courses = repository.GetCourseSummariesFor(User.Identity.GetUserId());
            return View(courses);
        }

        public ActionResult Class(int id)
        {
            var repository = new TeacherRepository();
            var courses = repository.GetRosterBy(id);
            return View(courses);
        }

        public ActionResult Delete(string UserId, int ClassId)
        {
            var repository = new TeacherRepository();
            repository.RemoveStudent(UserId, ClassId);
            TempData["message"] = "Student Removed!";
            
            return RedirectToAction("Class", new {id = ClassId});
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
	}
}