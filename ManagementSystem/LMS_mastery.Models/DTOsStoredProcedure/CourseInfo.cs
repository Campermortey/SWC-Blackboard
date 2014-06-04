using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsStoredProcedure
{
    public class CourseInfo
    {
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Detail { get; set; }
        public byte? GradeLevel { get; set; }
        public int SectionId { get; set; }
        public int TeacherId { get; set; }   
        public int Period { get; set; }
        public string Room { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }
        public bool IsArchived { get; set; }
    }
}
