using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class TeacherSearch
    {

        //student search
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte GradeLevel { get; set; }
        public int UserId { get; set; }

    }
}
