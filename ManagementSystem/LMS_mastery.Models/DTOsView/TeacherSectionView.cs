using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsView
{
    public class TeacherSectionView
    {
      //  TeacherRoster _roster = new TeacherRoster();

      //  TeacherSearch _search = new TeacherSearch();
        public TeacherSearch Search { get; set; }
        public TeacherRoster Roster { get; set; }

    }
}
