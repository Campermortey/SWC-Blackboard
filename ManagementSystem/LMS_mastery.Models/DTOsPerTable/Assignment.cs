using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsPerTable
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int SectionId { get; set; }
        public int AssignmentTypeId { get; set; }
        public string Title { get; set; }
        public int? Points { get; set; }
        public string Detail { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
