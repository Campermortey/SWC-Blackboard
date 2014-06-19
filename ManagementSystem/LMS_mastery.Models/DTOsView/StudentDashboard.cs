using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class StudentDashboard
    {
        public string Name { get; set; }
        public char LetterGrade { get; set; }
        public int ClassId { get; set; }
        public int RosterId { get; set; }
    }
}
