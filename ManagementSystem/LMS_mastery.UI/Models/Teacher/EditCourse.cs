using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMS_mastery.Models.DTOsPerTable;

namespace LMS_mastery.UI.Models.Teacher
{
    public class EditCourse
    {
        //validation dto
        [Required(ErrorMessage = "Please enter the course name")]
        public string Name { get; set; }

        public byte? GradeLevel { get; set; }

        [Required(ErrorMessage = "Please enter a subject for the course")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the start date")]
        [Range(typeof(DateTime), "01/01/2000", "01/01/2020")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the ending date")]
        [Range(typeof(DateTime), "01/01/2000", "01/01/2020")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter a description for the course")]
        public string Description { get; set; }

        public bool IsArchived { get; set; }
        public int ClassId { get; set; }

        //reference the Analytics class
        public List<Analytics> ClassAnalytics { get; set; }

        //set up an empty constructor
        public EditCourse()
        {
            
        }

        //set up constructor that sets new values to the old values
        public EditCourse(Course course)
        {
            this.Name = course.Name;
            this.GradeLevel = course.GradeLevel;
            this.Subject = course.Subject;
            this.StartDate = course.StartDate;
            this.EndDate = course.EndDate;
            this.Description = course.Description;
            this.IsArchived = course.IsArchived;
            this.ClassId = course.ClassId;
        }

        //set up method which creates a course from this previous data

        public Course CreateCourseFromUIModel()
        {
            return new Course()
            {
                Name = this.Name,
                GradeLevel = this.GradeLevel.Value,
                Subject = this.Subject,
                StartDate = this.StartDate.Value,
                EndDate = this.EndDate.Value,
                Description = this.Description,
                IsArchived = this.IsArchived,
                ClassId = this.ClassId
            };
        }
    }
}