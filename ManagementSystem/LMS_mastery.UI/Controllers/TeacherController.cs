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
        // List of all classes the teacher teaches as well as # of students enrolled in course
        // GET: /Teacher/
        public ActionResult Index()
        {
            var repository = new TeacherRepository();
            var courses = repository.GetCourseSummariesFor(User.Identity.GetUserId());
            
            return View(courses);
        }

        // Shows all the students enrolled in the class. Passed in ClassId
        public ActionResult Class(int id)
        {
            var repository = new TeacherRepository();
            var students = repository.GetRosterBy(id);
            return View(students);
        }

        //Deletes a student from a course. Sets "IsDeleted" to '1'. 
        [HttpPost]
        public ActionResult Delete(string UserId, int ClassId)
        {
            var repository = new TeacherRepository();
            repository.RemoveStudent(UserId, ClassId);
            //passes this message back to "Class" 
            TempData["message"] = "Student Removed!";
            
            //redirects back to the Class where the ClassId is the ClassId
            return RedirectToAction("Class", new {id = ClassId});
        }

        //Edit a course 
        public ActionResult Edit(int id)
        {
            var repository = new TeacherRepository();

            //Get the course by the ClassId
            var course = repository.GetCourseById(id);

            //Create a new Course with the course passed in
            var model = new EditCourse(course);
            return View(model);
        }

        //The POST for the Edit
        [HttpPost]
        public ActionResult Edit(EditCourse course)
        {
            //If everything is Valid in the form then it proceeds
            if (ModelState.IsValid)
            {
                //Creates a new "dto" which has the validated information
                var dto = course.CreateCourseFromUIModel();

                //sets the UserId = the UserId of the User logged in
                dto.UserId = User.Identity.GetUserId();

                var repository = new TeacherRepository();

                //Saves it to the repository
                repository.EditCourse(dto);

                //Pass this tempdata back to the index
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