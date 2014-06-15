using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class TeacherDashboard
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public bool IsArchived { get; set; }


    }
}
