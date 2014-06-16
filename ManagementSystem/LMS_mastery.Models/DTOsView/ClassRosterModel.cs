using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_mastery.Models.DTOsStoredProcedure;

namespace LMS_mastery.Models.DTOsView
{
    public class ClassRosterModel
    {
        public List<TeacherRoster> Roster { get; set; }
        public RosterSearchRequest SearchRequest { get; set; }
        public List<TeacherSearch> SearchResults { get; set; }
        public RosterAddRequest AddRequest { get; set; }
    }
}
