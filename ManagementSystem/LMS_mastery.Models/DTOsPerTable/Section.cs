using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsPerTable
{
    public class Section
    {
        public int SectionId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int Period { get; set; }
        public string Room { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }
    }
}
