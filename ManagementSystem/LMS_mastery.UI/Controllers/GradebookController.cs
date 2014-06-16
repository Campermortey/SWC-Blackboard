using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_mastery.Data;

namespace LMS_mastery.UI.Controllers
{
    public class GradebookController : Controller
    {
        //
        // GET: /Gradebook/
        public ActionResult GradebookView(int id)
        {
            var repository = new TeacherRepository();
            var model = repository.GetGradebookViews(id);

            return View(model);
        }
	}
}