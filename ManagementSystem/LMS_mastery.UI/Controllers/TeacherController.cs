using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using LMS_mastery.Data;
using LMS_mastery.Models.DTOsPerTable;
using LMS_mastery.UI.Models.Teacher;
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
            var students = repository.GetRosterBy(id);
            return View(students);
        }

        [HttpPost]
        public ActionResult Delete(string UserId, int ClassId)
        {
            var repository = new TeacherRepository();
            repository.RemoveStudent(UserId, ClassId);
            TempData["message"] = "Student Removed!";
            
            return RedirectToAction("Class", new {id = ClassId});
        }

        public ActionResult Edit(int id)
        {
            var repository = new TeacherRepository();
            var course = repository.GetCourseById(id);
            var model = new EditCourse(course);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCourse course)
        {
            if (ModelState.IsValid)
            {
                var dto = course.CreateCourseFromUIModel();
                dto.UserId = User.Identity.GetUserId();

                var repository = new TeacherRepository();
                repository.EditCourse(dto);

                TempData["message"] = "Class edited!";
                TempData["messageType"] = "Success";

                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult AddCourse()
        {
           
            return View(new AddCourse());
        }

        [HttpPost]
        public ActionResult AddCourse(AddCourse course)
        {
            if (ModelState.IsValid)
            {
                var dto = course.CreateCourseFromUIModel();
                dto.UserId = User.Identity.GetUserId();

                var repository = new TeacherRepository();
                repository.AddCourse(dto);

                return RedirectToAction("Index");
            }
            return View(course);
        }
	}
}