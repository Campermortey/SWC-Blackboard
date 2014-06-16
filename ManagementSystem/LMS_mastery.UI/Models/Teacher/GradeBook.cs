using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.UI.Models.Teacher
{
    public class GradeBook
    {
        // roster  // inside each roster student a List<GradeBookEntry>

        // class assignment list

        public List<GradebookView> GradeViews { get; set; }
        //public List<Homeworks>  
    }
}