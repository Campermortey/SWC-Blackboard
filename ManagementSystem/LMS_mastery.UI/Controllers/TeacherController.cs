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

            // Get a new ClassRoster Model
            var model = new ClassRosterModel();

            // Set the roster equal to the output of "GetRosterById"
            model.Roster = repository.GetRosterBy(id);

            // Search request is equal to a new RosterSearchRequest
            model.SearchRequest = new RosterSearchRequest();

            //Results equal to the list of TeacherSearch
            model.SearchResults = new List<TeacherSearch>();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Class(int id, ClassRosterModel model)
        {
            //create a new repository
            var repository = new TeacherRepository();

            // Set the searchrequest.ClassId to the Id passed in
            model.SearchRequest.ClassId = id;
            
            // Set the roster equal to the repository's get by roster Id
            model.Roster = repository.GetRosterBy(id);

            // Allows the search boxes to still contain the typed in data
            model.SearchRequest = model.SearchRequest;

            //Set the results equal to the output for "Search
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
            var repository = new TeacherRepository();
            //If everything is Valid in the form then it proceeds
            if (ModelState.IsValid)
            {
                //Creates a new "dto" which has the validated information
                var dto = course.CreateCourseFromUIModel();

                //sets the UserId = the UserId of the User logged in
                dto.UserId = User.Identity.GetUserId();

                //Saves it to the repository
                repository.EditCourse(dto);

                //Pass this tempdata back to the index
                TempData["message"] = "Class edited!";
                TempData["messageType"] = "Success";

                return RedirectToAction("Index");
            }
            var courses = repository.GetCourseById(course.ClassId);
            //Create a new Course with the course passed in
            var model = new EditCourse(courses);

            //Get the class grades passed in Class Id save to Model.ClassAnalytics List
            model.ClassAnalytics = repository.GetClassGrades(course.ClassId);
            return View(model);
        }

        // Add a course view
        public ActionResult AddCourse()
        {
           
            return View(new AddCourse());
        }

        // Add a course
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

        // Add a student from the list of students
        [HttpPost]
        public ActionResult AddStudent(string UserId, int ClassId)
        {
            var repository = new TeacherRepository();
            
            // AddToRoster takes parameters UserId and ClassId
            repository.AddToRoster(UserId, ClassId);

            TempData["studentMessage"] = "Student saved to course!";

            // Must take in route data
            return RedirectToAction("Class", new{id = ClassId});
        }
	}
}