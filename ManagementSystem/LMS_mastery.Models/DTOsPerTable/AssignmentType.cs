using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsPerTable
{
    public class AssignmentType
    {
        public int AssignmentTypeId { get; set; }
        public string Title { get; set; }
        public int? TotalPoints { get; set; }
    }
}
