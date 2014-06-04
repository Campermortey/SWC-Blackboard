using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsPerTable
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }  
        public int DepartmentId { get; set; }    
        public string Detail { get; set; }
        public byte? GradeLevel { get; set; }
    }
}
