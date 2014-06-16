using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsStoredProcedure
{
    public class RosterAddRequest
    {
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public int RosterId { get; set; }

    }
}
