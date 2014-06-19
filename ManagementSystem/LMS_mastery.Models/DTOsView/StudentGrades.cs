using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class StudentGrades
    {
        public string Name { get; set; }
        public List<AssignmentGrade> Grades { get; set; }

    }

    public class AssignmentGrade
    {
        public int RosterId { get; set; }
        public string Name { get; set; }
        public int AssignmentId { get; set; }
        public decimal Score { get; set; }
        public char LetterGrade { get; set; }
        public string Percentage { get { return (Score).ToString("P0"); } }
    }
}
