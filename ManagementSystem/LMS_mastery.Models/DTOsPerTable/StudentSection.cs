﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_mastery.Models.DTOsPerTable
{
    public class StudentSection
    {
        public int SectionId { get; set; }
        public int StudentId { get; set; }
        public int? CumulativeGrade { get; set; }
    }
}
