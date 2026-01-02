using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequest
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Display(Name ="Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }


        [Required]
        [Display(Name = "End Date")]
        public DateOnly EndDate { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        
        public string? EmployeeId { get; set; } 

        [Display(Name ="Request Comment")]
        [MaxLength(150)]
        public string? RequestComments { get; set; }

        public SelectList? LeaveTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date Must be Before the End Date", new[] { nameof(StartDate), nameof(EndDate) });
            }

           
        }
    }
}