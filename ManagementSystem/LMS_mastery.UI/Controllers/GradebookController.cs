using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LMS_mastery.Data;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.UI.Controllers
{
    public class GradebookController : ApiController
    {
        // Show the GradeBook View
        public GradebookView Get(int id)
        {
            var repo = new GradeBookRepository();

            // return the GradeBook View
            return repo.GetGradebookFor(id);
        }

       public HttpStatusCode Post(EditAssignment edit)
       {
            var repo = new GradeBookRepository();
           repo.EditTheAssignment(edit);

           return HttpStatusCode.OK;
       }
    }
}
