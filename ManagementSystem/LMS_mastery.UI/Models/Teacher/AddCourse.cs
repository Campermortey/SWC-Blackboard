using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMS_mastery.Models.DTOsPerTable;

namespace LMS_mastery.UI.Models.Teacher
{
    public class AddCourse
    {
        [Required(ErrorMessage = "Please enter the course name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the grade level for the course")]
        public byte? GradeLevel { get; set; }

        [Required(ErrorMessage = "Please enter a subject for the course")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the start date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the ending date")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter a description for the course")]
        public string Description { get; set; }

        public Course CreateCourseFromUIModel()
        {
            return new Course()
            {
                Name = this.Name,
                Description = this.Description,
                Subject = this.Subject,
                GradeLevel = this.GradeLevel.Value,
                StartDate = this.StartDate.Value,
                EndDate = this.EndDate.Value
            };
        }
    }
}