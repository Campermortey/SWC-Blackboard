using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using LMS_mastery.Data;
using LMS_mastery.Models.DTOsPerTable;
using LMS_mastery.Models.DTOsStoredProcedure;
using LMS_mastery.Models.DTOsView;
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
        // Also returns all the students available to add to the class

        public ActionResult Class(int id)
        {
            var repository = new TeacherRepository();
            var model = new ClassRosterModel();
            model.Roster = repository.GetRosterBy(id);
            model.SearchRequest = new RosterSearchRequest();
            model.SearchResults = new List<TeacherSearch>();


            
            return View(model);
        }

        [HttpPost]
        public ActionResult Class(int id, ClassRosterModel model)
        {
            //create a new repository
            var repository = new TeacherRepository();

            model.SearchRequest.ClassId = id;
            
            model.Roster = repository.GetRosterBy(id);
            model.SearchRequest = model.SearchRequest;
            model.SearchResults = repository.Search(model.SearchRequest);
           
           //return view with this model
            return View(model);
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

            //Get the class grades passed in Class Id save to Model.ClassAnalytics List
            model.ClassAnalytics = repository.GetClassGrades(id);
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

        [HttpPost]
        public ActionResult AddStudent(ClassRosterModel model)
        {
            var repository = new TeacherRepository();
            
            repository.AddToRoster(model.AddRequest);
            
            return RedirectToAction("Class", model.AddRequest.ClassId);
        }
	}
}