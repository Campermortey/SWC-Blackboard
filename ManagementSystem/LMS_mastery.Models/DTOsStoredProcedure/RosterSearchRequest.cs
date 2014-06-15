using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsStoredProcedure
{
    public class RosterSearchRequest
    {
        public int ClassId { get; set; }
        public string LastName { get; set; }
        public byte? GradeLevel { get; set; }
    }
}
