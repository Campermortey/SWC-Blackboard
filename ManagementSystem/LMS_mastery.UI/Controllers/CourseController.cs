using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_mastery.Data;
using LMS_mastery.Models.DTOsView;
using LMS_mastery.UI.Models;

namespace LMS_mastery.UI.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Gradebook(int id)
        {
            return View();
        }

        

        public ActionResult AddAssignment(int id)
        {
            var model = new AddAssignment();
            model.ClassId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAssignment(AddAssignment assignment)
        {
            var repository = new GradeBookRepository();
            if (ModelState.IsValid)
            {
                var dto = assignment.CreateAssignmentFromUIModel();
                dto.ClassId = assignment.ClassId;
                repository.AddAssignment(dto);
                return RedirectToAction("Gradebook", new { id = dto.ClassId });
            }
            return View(assignment);

        }

        public ActionResult EditAssignment(int id)
        {
            return RedirectToAction("Assignments");
        }
	}
}