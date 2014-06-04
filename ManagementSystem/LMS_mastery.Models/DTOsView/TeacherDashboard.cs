using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class TeacherDashboard
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public string CourseName { get; set; }
        public byte StudentCount { get; set; }
        public bool IsArchived { get; set; }
        public byte Period { get; set; }

    }
}
