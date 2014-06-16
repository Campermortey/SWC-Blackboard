using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class TeacherRoster
    {
        //getting a roster of all students in a section
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }


        ////reference the TeacherSearch clas to model bind student search
        //public List<TeacherSearch> RosterSearch { get; set; }
    }
}
