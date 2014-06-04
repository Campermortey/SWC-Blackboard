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
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public byte GradeLevel { get; set; }
    }
}
