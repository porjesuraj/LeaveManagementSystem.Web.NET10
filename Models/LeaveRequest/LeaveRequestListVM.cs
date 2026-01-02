using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Models.LeaveRequest
{
    public class LeaveRequestListVM
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }


        [Required]
        [Display(Name = "End Date")]
        public DateOnly EndDate { get; set; }

        [Display(Name = "Total Days")]
        public int NumberOfDays { get; set; }


        [Display(Name = "Leave Type")]
        [Required]
        public string LeaveType { get; set; }


        [Display(Name = "Request Comment")]
        [MaxLength(150)]
        public string? RequestComments { get; set; }


        public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }
    }
}