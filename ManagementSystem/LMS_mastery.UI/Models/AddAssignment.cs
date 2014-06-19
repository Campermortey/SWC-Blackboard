using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.UI.Models
{
    public class AddAssignment
    {
        

        [Required(ErrorMessage = "Please enter the assignment name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the possible points")]
        public int PossiblePoints { get; set; }

        [Required(ErrorMessage = "Please enter the due date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please enter the description")]
        public string Description { get; set; }

        public int ClassId { get; set; }

        //public AddAssignment()
        //{
            
        //}

        //public AddAssignment(Assignment assignment)
        //{
        //    this.Name = assignment.Name;
        //    this.PossiblePoints = assignment.PossiblePoints;
        //    this.DueDate = assignment.

        //}

        public Assignment CreateAssignmentFromUIModel()
        {
            return new Assignment()
            {
                ClassId = this.ClassId,
                Name = this.Name,
                PossiblePoints = this.PossiblePoints,
                DueDate = this.DueDate,
                Description = this.Description
            };
        }
    }
}