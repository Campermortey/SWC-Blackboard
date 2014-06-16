using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class GradebookView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char LetterGrade { get; set; }
        public string Name { get; set; }
        public decimal Percent { get; set; }
    }
}
