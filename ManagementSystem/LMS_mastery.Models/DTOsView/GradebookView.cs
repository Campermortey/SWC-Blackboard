using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    // Main model for the Gradebook View
    public class GradebookView
    {
        public string CourseName { get; set; }
        public List<GradebookAssignment> Assignments { get; set; }
        public List<GradebookStudent> Students { get; set; }
    }

    // Each assignment has an Id and a name
    public class GradebookAssignment
    {
        public int AssignmentId { get; set; }
        public string Name { get; set; }
    }

    // Each student has a list of assignments with scores
    public class GradebookStudent
    {
        public int RosterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LetterGrade { get; set; }
        public List<GradebookStudentGrade> Grades { get; set; }
    }

    // Assignments with points, scores, and points possible per RosterId (student)
    public class GradebookStudentGrade
    {
        public int RosterId { get; set; }
        public int AssignmentId { get; set; }
        public int? Points { get; set; }
        public decimal? Score { get; set; }
        public int PossiblePoints { get; set; }
    }

    public class GradebookLetterGrade
    {
        public int RosterId { get; set; }
        public string LetterGrade { get; set; }
    }

    public class EditAssignment
    {
        public int AssignmentId { get; set; }
        public int RosterId { get; set; }
        public decimal Points { get; set; }
    }

    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int PossiblePoints { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
