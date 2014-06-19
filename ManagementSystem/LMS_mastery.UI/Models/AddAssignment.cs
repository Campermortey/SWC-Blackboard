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
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Please enter the description")]
        public string Description { get; set; }

        public int ClassId { get; set; }

        public Assignment CreateAssignmentFromUIModel()
        {
            return new Assignment()
            {
                ClassId = this.ClassId,
                Name = this.Name,
                PossiblePoints = this.PossiblePoints,
                DueDate = this.DueDate.Value,
                Description = this.Description
            };
        }
    }
}